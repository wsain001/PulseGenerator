using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using ZedGraph;
using Digital_Pulse_Generator.WaveCalculator;

namespace Digital_Pulse_Generator
{
    public partial class Pulse_Generator : Form
    {
        private enum WaveType { Gaussian, Sine, Square, Triangle };

        private Regex numbers_only = new Regex(@"^\d+(\.\d+)?$");
        private double m_SamplingFrequency = 6; // in Mhz
        private double m_SamplingPeriod = 167; // Period in nanoseconds = (1 / frequency) seconds * (10^9 nanoseconds/seconds)
        private double m_GraphXAxisRange = 6000;
        private double m_GraphAxisXMin = 0;
        private double m_GraphAxisYMax = 5;
        private double m_GraphAxisYMin = 0;
        private int m_ADBits = 12;
        private double m_ADVoltageHigh = 5;
        private double m_ADVoltageLow = 0;
        private double gaussian_a = 1;
        private double gaussian_b = 5000;
        private double gaussian_c = 800;
        private PointF startPt;
        private double startX, startY;
        private bool isDragPoint = false;
        private CurveItem graph;
        private int dragIndex;
        private PointPair startPair;
        private double m_ADStepCount;

        private IWave m_currentWave;
        private GaussianCurve m_GaussianWave;
        private SineWave m_SineWave;
        private SquareWave m_SquareWave;
        private TriangleWave m_TriangleWave;


        public Pulse_Generator()
        {
            InitializeComponent();                       
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            update_textboxes();
            initializeGraph();
            InitializeWaveType();
            InitializeADSettings();
            UpdateWaveParameters();

            button_GenerateWave_Click(null, EventArgs.Empty);
        }

        private void Pulse_Generator_FormClosed(object sender, FormClosedEventArgs e)
        {
            string lastWaveType;

            if (radioButton_Gaussian.Checked)
            {
                lastWaveType = WaveType.Gaussian.ToString();
            }
            else if (radioButton_SineWave.Checked)
            {
                lastWaveType = WaveType.Sine.ToString();
            }
            else if (radioButton_SquareWave.Checked)
            {
                lastWaveType = WaveType.Square.ToString();
            }
            else // if (radioButton_TriangleWave.Checked)
            {
                lastWaveType = WaveType.Triangle.ToString();
            }
            
            Properties.Settings.Default.LastWaveType = lastWaveType;
            Properties.Settings.Default.ADVoltageHigh = m_ADVoltageHigh;
            Properties.Settings.Default.ADVoltageLow = m_ADVoltageLow;
            Properties.Settings.Default.ADResolution = m_ADBits;
            Properties.Settings.Default.ADFrequency = m_SamplingFrequency;

            Properties.Settings.Default.Save();
        }

        private void initializeGraph()
        {
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.Title.Text = "Pulse";
            pane.XAxis.Title.Text = "ns";
            pane.YAxis.Title.Text = "Voltage";
            toolStripMenuItem_GraphShowGrid.Checked = true;
            update_scales();
        }
       
        private void InitializeWaveType()
        {
            WaveType waveType = (WaveType)Enum.Parse(typeof(WaveType), Properties.Settings.Default.LastWaveType);

            switch (waveType)
            {
                case WaveType.Sine:
                {
                    radioButton_SineWave.Checked = true;
                    break;
                }

                case WaveType.Square:
                {
                    radioButton_SquareWave.Checked = true;
                    break;
                }

                case WaveType.Triangle:
                {
                    radioButton_TriangleWave.Checked = true;
                    break;
                }

                default:
                {
                    radioButton_Gaussian.Checked = true;
                    break;
                }
            }

        }

        private void InitializeADSettings()
        {
            m_ADVoltageHigh = Properties.Settings.Default.ADVoltageHigh;
            m_ADVoltageLow = Properties.Settings.Default.ADVoltageLow;
            m_ADBits = Properties.Settings.Default.ADResolution;
            m_SamplingFrequency = Properties.Settings.Default.ADFrequency;
        }

        private void SetWaveParametersTextBoxes(string amplitude, string period, string phase)
        {
            textBox_Amplitude.Text = amplitude;
            textBox_Period.Text = period;
            textBox_Phase.Text = phase;
        }

        private void UpdateWaveParameters()
        {
            if (radioButton_Gaussian.Checked)
            {
                SetWaveParametersTextBoxes(Properties.Settings.Default.GaussianAmplitude.ToString(),
                                           Properties.Settings.Default.GaussianHalfPeriod.ToString(),
                                           Properties.Settings.Default.GaussianC.ToString());

            }
            else if (radioButton_SineWave.Checked)
            {
                SetWaveParametersTextBoxes(Properties.Settings.Default.SquareAmplitude.ToString(),
                                           Properties.Settings.Default.SinePeriod.ToString(),
                                           Properties.Settings.Default.SinePhase.ToString());
            }
            else if (radioButton_SquareWave.Checked)
            {
                SetWaveParametersTextBoxes(Properties.Settings.Default.SquareAmplitude.ToString(),
                                           Properties.Settings.Default.SquarePeriod.ToString(),
                                           Properties.Settings.Default.SquareHarmonic.ToString());
            }
            else if (radioButton_TriangleWave.Checked)
            {
                SetWaveParametersTextBoxes(Properties.Settings.Default.TriangleAmplitude.ToString(),
                                           Properties.Settings.Default.TrianglePeriod.ToString(),
                                           Properties.Settings.Default.TriangleHarmonic.ToString());
            }
        }

        private void update_textboxes()
        {
            textBox_Frequency.Value = Convert.ToDecimal(m_SamplingFrequency);
            // TODO: ?????
            //textBox_Amplitude.Text = gaussian_a.ToString();
            //textBox_Period.Text = gaussian_b.ToString();
            //textBox_Phase.Text = gaussian_c.ToString();
            ad_bits_textbox.Text = m_ADBits.ToString();
            textBox_ADReferenceHigh.Text = m_ADVoltageHigh.ToString();
            textBox_ADReferenceLow.Text = m_ADVoltageLow.ToString();

            if (m_currentWave != null)
            {
                if (radioButton_PulseInfoAnalog.Checked)
                {
                    textBox_PulseInformation.Text = m_currentWave.GetAnalogStats();
                }
                else
                {
                    textBox_PulseInformation.Text = m_currentWave.GetDigitalStats(m_ADBits, m_ADVoltageHigh, m_ADVoltageLow);
                }
            }
        }

        private void update_scales()
        {
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.XAxis.Scale.Min = m_GraphAxisXMin;
            pane.XAxis.Scale.Max = m_GraphXAxisRange;

            pane.YAxis.Scale.Min = m_GraphAxisYMin;
            pane.YAxis.Scale.Max = m_GraphAxisYMax;

            setScaleMagnitude();
        }

        private void setScaleMagnitude()
        {
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.XAxis.Title.IsOmitMag = true;

            if(m_GraphXAxisRange > 1000000)
            {
                pane.XAxis.Scale.Mag = 6;
                pane.XAxis.Title.Text = "ms";
            }
            else if (m_GraphXAxisRange > 1000)
            {
                pane.XAxis.Scale.Mag = 3;
                pane.XAxis.Title.Text = "\u00B5s";
            }
            else 
            {
                pane.XAxis.Scale.Mag = 0;
                pane.XAxis.Title.Text = "ns";
            }
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
        }

        private void frequency_TextChanged(object sender, EventArgs e)
        {
            OnFrequencyChanged();
        }

        private void frequency_KeyUp(object sender, KeyEventArgs e)
        {
            OnFrequencyChanged();
        }

        private void OnFrequencyChanged()
        {
            m_SamplingFrequency = Convert.ToDouble(textBox_Frequency.Value);
            m_SamplingPeriod = 1000 / m_SamplingFrequency;

            period_text.Text = m_SamplingPeriod.ToString("0");
            m_ADStepCount = CalculateADStepCount(m_ADVoltageHigh, m_ADVoltageLow, m_ADBits);
        }

        private void textbox_Amplitude_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Amplitude.Text != null && !textBox_Amplitude.Text.Equals("") && numbers_only.IsMatch(textBox_Amplitude.Text))
                gaussian_a = Convert.ToDouble(textBox_Amplitude.Text);
        }

        private void textBox_Period_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Period.Text != null && !textBox_Period.Text.Equals("") && numbers_only.IsMatch(textBox_Period.Text))
                gaussian_b = Convert.ToDouble(textBox_Period.Text);
        }

        private void textBox_Phase_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Phase.Text != null && !textBox_Phase.Text.Equals("") && numbers_only.IsMatch(textBox_Phase.Text))
                gaussian_c = Convert.ToDouble(textBox_Phase.Text);
        }

        private void button_GenerateWave_Click(object sender, EventArgs e)
        {
            Draw_Function();
        }

        private bool zedGraphControl1_MouseMoveEvent(ZedGraphControl control, MouseEventArgs e)
        {
            statusStripUpdate(control, e);
            return DragPoint(control, e);
        }

        private bool zedGraphControl1_MouseDownEvent(ZedGraphControl control, MouseEventArgs e)
        {
            return ActivateDragPoint(control, e);
        }

        private bool zedGraphControl1_MouseUpEvent(ZedGraphControl sender, MouseEventArgs e)
        {
            if (isDragPoint)
                // dragging operation is no longer active
                isDragPoint = false;
            return false;
        }

        private void ad_voltage_textbox_TextChanged(object sender, EventArgs e)
        {
            double voltage;

            if (double.TryParse(textBox_ADReferenceHigh.Text, out voltage))
            {
                m_ADVoltageHigh = voltage;
            }

            if (double.TryParse(textBox_ADReferenceLow.Text, out voltage))
            {
                m_ADVoltageLow = voltage;
            }
                        
            m_ADStepCount = CalculateADStepCount(m_ADVoltageHigh, m_ADVoltageLow, m_ADBits);            
        }

        private static double CalculateADStepCount(double highADVoltage, double lowADVoltage, int ADBitCount )
        {
            return (highADVoltage - lowADVoltage) / Math.Pow(2, ADBitCount);
        }

        private void ad_bits_textbox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ad_bits_textbox.Text) && (numbers_only.IsMatch(ad_bits_textbox.Text)))
            {
                m_ADBits = Convert.ToInt32(ad_bits_textbox.Text);
                m_ADStepCount = CalculateADStepCount(m_ADVoltageHigh, m_ADVoltageLow, m_ADBits);
            }
        }

        private bool ActivateDragPoint(ZedGraphControl control, MouseEventArgs e)
        {
            // mousedown combination
            GraphPane myPane = control.GraphPane;
            PointF mousePt = new PointF(e.X, e.Y);

            // find the point that was clicked, and make sure the point list is editable
            // and that it's a primary Y axis (the first Y or Y2 axis)
            if (myPane.FindNearestPoint(mousePt, out graph, out dragIndex) &&
                     graph.Points is PointPairList &&
                     graph.YAxisIndex == 0)
            {
                // save the starting point information
                startPt = mousePt;
                startPair = graph.Points[dragIndex];
                // indicate a drag operation is in progress
                isDragPoint = true;
                // get the scale values for the start of the drag
                double startX2, startY2;
                myPane.ReverseTransform(mousePt, out startX, out startX2, out startY, out startY2);
                // if it's a Y2 axis, use that value instead of Y
                if (graph.IsY2Axis)
                    startY = startY2;

                return true;
            }
            return false;
        }
        private bool DragPoint(ZedGraphControl control, MouseEventArgs e)
        {
            GraphPane myPane = control.GraphPane;
            PointF mousePt = new PointF(e.X, e.Y);

            // see if a dragging operation is underway
            if (isDragPoint)
            {
                // get the scale values that correspond to the current point
                double curX, curX2, curY, curY2;
                myPane.ReverseTransform(mousePt, out curX, out curX2, out curY, out curY2);
                // if it's a Y2 axis, use that value instead of Y
                if (graph.IsY2Axis)
                    curY = curY2;
                // calculate the new scale values for the point
                PointPair newPt = new PointPair(startPair.X + curX - startX, startPair.Y + curY - startY);
                // save the data back to the point list
                (graph.Points as PointPairList)[dragIndex] = newPt;
                // force a redraw
                control.Refresh();
            }
            return false;
        }

        private void statusStripUpdate(ZedGraphControl sender, MouseEventArgs e)
        {
            // Save the mouse location
            PointF mousePt = new PointF(e.X, e.Y);
            // Find the Chart rect that contains the current mouse location
            GraphPane pane = sender.MasterPane.FindChartRect(mousePt);

            // If pane is non-null, we have a valid location.  Otherwise, the mouse is not
            // within any chart rect.
            if (pane != null)
            {
                double x, y;
                // Convert the mouse location to X, and Y scale values
                pane.ReverseTransform(mousePt, out x, out y);
                // Format the status label text
                toolStripStatusLabel1.Text = "(" + x.ToString("f2") + ", " 
                    + String.Format("{0:0.###################}", y) + ")";
            }
            else
                // If there is no valid data, then clear the status label text
                toolStripStatusLabel1.Text = string.Empty;
        }
                
        private void Draw_Function()
        {
            if (radioButton_Gaussian.Checked)
            {
                Properties.Settings.Default.GaussianAmplitude = double.Parse(textBox_Amplitude.Text);
                Properties.Settings.Default.GaussianHalfPeriod = double.Parse(textBox_Period.Text);
                Properties.Settings.Default.GaussianC = double.Parse(textBox_Phase.Text);

                DrawGaussianPulse();
            }
            else if (radioButton_SineWave.Checked)
            {
                Properties.Settings.Default.SineAmplitude = double.Parse(textBox_Amplitude.Text);
                Properties.Settings.Default.SinePeriod = double.Parse(textBox_Period.Text);
                Properties.Settings.Default.SinePhase = double.Parse(textBox_Phase.Text);

                DrawSineWave();
            }
            else if (radioButton_SquareWave.Checked)
            {
                Properties.Settings.Default.SquareAmplitude = double.Parse(textBox_Amplitude.Text);
                Properties.Settings.Default.SquarePeriod = double.Parse(textBox_Period.Text);
                Properties.Settings.Default.SquareHarmonic = int.Parse(textBox_Phase.Text);

                DrawSquareWave();
            }
            else if (radioButton_TriangleWave.Checked)
            {
                Properties.Settings.Default.TriangleAmplitude = double.Parse(textBox_Amplitude.Text);
                Properties.Settings.Default.TrianglePeriod = double.Parse(textBox_Period.Text);
                Properties.Settings.Default.TriangleHarmonic = int.Parse(textBox_Phase.Text);

                DrawTriangleWave();
            }

            update_scales();
            update_textboxes();
            refresh_graph();
        }

        private void DrawGaussianPulse()
        {
            m_GraphXAxisRange = gaussian_b * 2;

            double a = double.Parse(textBox_Amplitude.Text);
            double b = double.Parse(textBox_Period.Text);
            double c = double.Parse(textBox_Phase.Text);

            m_GaussianWave = new GaussianCurve(a,
                                               b,
                                               c,
                                               m_GraphXAxisRange,
                                               m_SamplingPeriod);

            m_GraphAxisYMax = Math.Round(m_GaussianWave.Peak + m_GaussianWave.Peak / 4, 2);
            m_GraphAxisYMin = 0;

            m_currentWave = m_GaussianWave;
        }

        private void DrawSineWave()
        {
            // Set the x axis range to be the period of the sine wave.
            m_GraphXAxisRange = double.Parse(textBox_Period.Text);

            // Get the amplitude of the sine wave from the user
            double amplitude = Convert.ToDouble(textBox_Amplitude.Text);

            // Get the phase of the sine wave from the user
            double phase = Convert.ToDouble(textBox_Phase.Text);

            // Create the sine wave
            m_SineWave = new SineWave(amplitude,
                                      m_GraphXAxisRange,
                                      phase,
                                      m_SamplingPeriod);

            m_GraphAxisYMax = Math.Round(amplitude + (amplitude / 4), 2);
            m_GraphAxisYMin = -1 * m_GraphAxisYMax;

            m_currentWave = m_SineWave;
        }

        private void DrawSquareWave()
        {
            // Set the x axis range to be the period of the wave.
            m_GraphXAxisRange = double.Parse(textBox_Period.Text);

            // Get the amplitude of the wave from the user
            double amplitude = Convert.ToDouble(textBox_Amplitude.Text);

            // Get the phase of the wave from the user
            double phase = Convert.ToDouble(textBox_Phase.Text);

            // Create the square wave
            //m_SquareWave = new SquareWave(amplitude,
            //                              m_GraphXAxisRange,
            //                              phase,
            //                              m_SamplingPeriod);

            m_SquareWave = new SquareWave(amplitude,
                                          m_GraphXAxisRange,
                                          (int)phase,
                                          m_SamplingPeriod);

            // Set the graph y axis limits
            m_GraphAxisYMax = Math.Round(amplitude + (amplitude / 4), 2);
            m_GraphAxisYMin = -1 * m_GraphAxisYMax;

            
            // Set the current wave
            m_currentWave = m_SquareWave;
        }

        private void DrawTriangleWave()
        {
            // Set the x axis range to be the period of the wave.
            m_GraphXAxisRange = double.Parse(textBox_Period.Text);

            // Get the amplitude of the wave from the user
            double amplitude = Convert.ToDouble(textBox_Amplitude.Text);

            // Get the phase of the wave from the user
            double phase = Convert.ToDouble(textBox_Phase.Text);

            // Create the Triangle wave
            m_TriangleWave = new TriangleWave(amplitude,
                                              m_GraphXAxisRange,
                                              (int)phase,
                                              m_SamplingPeriod);

            // Set the graph y axis limits
            m_GraphAxisYMax = Math.Round(amplitude + (amplitude / 4), 2);
            m_GraphAxisYMin = -1 * m_GraphAxisYMax;

            // Set the current wave
            m_currentWave = m_TriangleWave;
        }

        private void refresh_graph()
        {
            // Clear the previous graph
            zedGraphControl1.GraphPane.CurveList.Clear();
            // Generate a blue curve with circle symbols
            if (m_currentWave != null && m_currentWave.PointsList.Count != 0)
                zedGraphControl1.GraphPane.AddCurve("", m_currentWave.PointsList, Color.Blue, SymbolType.Circle);

            // Tell ZedGraph to refigure the
            // axes since the data have changed
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
        }
        
        private void radioButtonWaveType_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                // Set formula image
                if (sender == radioButton_Gaussian)
                {
                    pictureBox_Formula.Image = Properties.Resources.GaussianPulse;
                }
                else if (sender == radioButton_SineWave)
                {
                    pictureBox_Formula.Image = Properties.Resources.SineWave;
                }
                else if (sender == radioButton_SquareWave)
                {
                    pictureBox_Formula.Image = Properties.Resources.Squarewave;
                }
                else if (sender == radioButton_TriangleWave)
                {
                    pictureBox_Formula.Image = Properties.Resources.TriangleWave;
                }

                // Set the label captions
                // Store the right edge position of the labels 
                int label_AmplitudeRight = label_Amplitude.Right;
                int label_PeriodRight = label_Period.Right;
                int label_PhaseRight = label_Phase.Right;
                                
                // Set the label text to represent the variables for the function
                if (sender == radioButton_Gaussian)
                {
                    label_Amplitude.Text = "Amplitude (a):";
                    label_Period.Text = "½ Period (b):";
                    label_Phase.Text = "c:";
                }
                else
                {
                    label_Amplitude.Text = "Amplitude (A):";
                    label_Period.Text = "Period:";

                    if ((sender == radioButton_SquareWave)
                         || (sender == radioButton_TriangleWave))
                    {
                        label_Phase.Text = "Harmonic (k):";
                    }
                    else
                    {
                        label_Phase.Text = "Phase (φ):";
                    }
                }

                // Set the left edge of the label so that the right edge is the same as
                // the original right (so it does not go under the text box).
                label_Amplitude.Left = label_AmplitudeRight - label_Amplitude.Width;
                label_Period.Left = label_PeriodRight - label_Period.Width;
                label_Phase.Left = label_PhaseRight - label_Phase.Width;


                UpdateWaveParameters();

            }
        }

        #region Main Menu

        #region Graph Menu Event Handlers

        private void toolStripMenuItem_GraphShowGrid_CheckedChanged(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.YAxis.MajorGrid.IsVisible = toolStripMenuItem_GraphShowGrid.Checked;
            zedGraphControl1.GraphPane.XAxis.MajorGrid.IsVisible = toolStripMenuItem_GraphShowGrid.Checked;
            zedGraphControl1.Refresh();
        }

        private void reset_zoom_button_Click(object sender, EventArgs e)
        {
            update_scales();
        }

        private void clear_graph_button_Click(object sender, EventArgs e)
        {
            m_currentWave = null;
            refresh_graph();
        }

        #endregion Graph Menu Event Handlers

        #region Edit Menu Event Handlers

        private void toolStripMenuItem_Edit_Click(object sender, EventArgs e)
        {
            if (ActiveControl is TextBoxBase)
            {
                TextBoxBase tb = (TextBoxBase)ActiveControl;

                toolStripMenuItem_EditUndo.Enabled = tb.CanUndo;
                toolStripMenuItem_EditCut.Enabled = tb.SelectionLength > 0;
                toolStripMenuItem_EditCopy.Enabled = toolStripMenuItem_EditCut.Enabled;
                toolStripMenuItem_EditPaste.Enabled = Clipboard.ContainsText();
                toolStripMenuItem_EditSelectAll.Enabled = tb.TextLength > 0;
            }
            else
            {
                toolStripMenuItem_EditUndo.Enabled = false;
                toolStripMenuItem_EditCut.Enabled = false;
                toolStripMenuItem_EditCopy.Enabled = false;
                toolStripMenuItem_EditPaste.Enabled = false;
                toolStripMenuItem_EditSelectAll.Enabled = false;
            }



            
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveControl is TextBoxBase)
            {
                TextBoxBase tb = (TextBoxBase)ActiveControl;

                if (tb.CanUndo)
                    tb.Undo();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveControl is TextBoxBase)
            {
                TextBoxBase tb = (TextBoxBase)ActiveControl;
                tb.Cut();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveControl is TextBoxBase)
            {
                TextBoxBase tb = (TextBoxBase)ActiveControl;
                tb.Copy();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveControl is TextBoxBase)
            {
                TextBoxBase tb = (TextBoxBase)ActiveControl;
                tb.Paste();
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveControl is TextBoxBase)
            {
                TextBoxBase tb = (TextBoxBase)ActiveControl;
                tb.SelectAll();
            }
        }

        #endregion Edit Menu Event Handlers

        #region File Menu Event Handlers

        private void ToolStripMenuItem_FileOpenDigital_Click(object sender, EventArgs e)
        {
            openDigitalGraph();

            update_scales();
            update_textboxes();
            refresh_graph();
        }

        private void toolStripMenuItem_FileOpenAnalog_Click(object sender, EventArgs e)
        {
            openAnalogGraph();

            update_scales();
            update_textboxes();
            refresh_graph();
        }

        private void openDigitalGraph()
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            string[] linesRead = File.ReadAllLines(openFileDialog1.FileName);

            m_currentWave = new Wave();

            double highPeak = 0;
            double lowPeak = 0;
            double x = 0;

            for (int i = 0; i < linesRead.Length; i++)
            {
                int digitalValue = int.Parse(linesRead[i]);

                double y = (digitalValue * (m_ADVoltageHigh - m_ADVoltageLow) / Math.Pow(2, m_ADBits)) + m_ADVoltageLow;
                
                m_currentWave.PointsList.Add(x, y);

                x += m_SamplingPeriod;
                highPeak = Math.Max(highPeak, y);
                lowPeak = Math.Min(lowPeak, y);
            }

            // Set graph viewable area
            m_GraphAxisYMax = Math.Round(highPeak + highPeak / 4, 2);
            m_GraphAxisYMin = Math.Round(lowPeak + lowPeak / 4, 2);
            m_GraphXAxisRange = (int)x;
        }

        private void openAnalogGraph()
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            string[] linesRead = File.ReadAllLines(openFileDialog1.FileName);

            m_currentWave = new Wave();

            double highPeak = 0;
            double lowPeak = 0;
            double x = 0;

            for (int i = 0; i < linesRead.Length; i++)
            {
                double y = Convert.ToDouble(linesRead[i]);
                m_currentWave.PointsList.Add(x, y);
            
                x += m_SamplingPeriod;
                highPeak = Math.Max(highPeak, y);
                lowPeak = Math.Min(lowPeak, y);
            }

            // Set graph viewable area
            m_GraphAxisYMax = Math.Round(highPeak + highPeak / 4, 2);
            m_GraphAxisYMin = Math.Round(lowPeak + lowPeak / 4, 2);
            m_GraphXAxisRange = (int)x;
        }

        private void toolStripMenuItem_FileSaveDigital_Click(object sender, EventArgs e)
        {
            SaveGraphData("{0:0}", ConvertAnalogToDigital);
        }

        private void toolStripMenuItem_FileSaveAnalog_Click(object sender, EventArgs e)
        {
            SaveGraphData("{0:0.###################################################}", CalculateAnalogData);
        }

        Func<double, double, double, double, double> ConvertAnalogToDigital = (voltage, ADBits, ADHighVoltage, ADLowVoltage) => 
            {
                if (voltage < ADLowVoltage)
                    return 0;
                else if (voltage > ADHighVoltage)
                    return Math.Pow(2, ADBits);
                else
                {                    
                    int digitalValue = (int)((Math.Pow(2, ADBits) * (voltage - ADLowVoltage)) / (ADHighVoltage - ADLowVoltage));
                    return digitalValue;
                }
            };
        Func<double, double, double, double, double> CalculateAnalogData = (voltage, ADBits, ADHighVoltage, ADLowVoltage) => { return voltage; };

        private void SaveGraphData(string dataFormat, Func<double, double, double, double, double> conversion)
        {
            if (m_currentWave != null && m_currentWave.PointsList.Count != 0
                && saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();

                for (int repetitions = 0; repetitions < int.Parse(textBox_Repetitions.Text); repetitions++)
                {
                    int startAt = 0;

                    if (repetitions > 0)
                        startAt = 1;

                    for (int i = startAt; i < m_currentWave.PointsList.Count; i++)
                    {
                        double value = conversion(m_currentWave.PointsList[i].Y,
                                                  m_ADBits,
                                                  m_ADVoltageHigh,
                                                  m_ADVoltageLow);

                        sb.AppendLine(String.Format(dataFormat, value));
                    }
                }

                File.WriteAllText(saveFileDialog1.FileName, sb.ToString());
            }
        }

        private void toolStripMenuItem_FileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion File Menu Event Handlers
        
        #endregion Main Menu

        #region Key press event for Numeric Only text boxes

        private void textbox_AllowOnlyNumericKeys_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-')
            {
                if ((sender == textBox_ADReferenceHigh)
                     || (sender == textBox_ADReferenceLow)
                     || (sender == textBox_Amplitude))
                {
                    // These text boxes allow for negative values
                    TextBox tb = (TextBox)sender;

                    if (     (tb.SelectionStart == 0)                  // The cursor is at the first position
                         && (    (string.IsNullOrEmpty(tb.Text))       // The text is empty
                              || (!tb.Text.Contains('-'))              // There is no - in the text
                              || (tb.SelectedText.Contains('-'))))     // The - is in the selected text
                        e.Handled = false;
                    else
                        e.Handled = true;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = ((TextBox)sender).Text.Contains('.');
            }
            else if ((!char.IsNumber(e.KeyChar)
                 && (!Char.IsControl(e.KeyChar))))
            {
                e.Handled = true;
            }
        }

        #endregion Key press event for Numeric Only text boxes

        private void radioButton_PulseInfoAnalog_CheckedChanged(object sender, EventArgs e)
        {
            update_textboxes();
        }

        private void toolStripMenuItem_HelpAbout_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }
    }
}
