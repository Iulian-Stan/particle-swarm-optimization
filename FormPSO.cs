using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Text;

namespace PSO
{
    public partial class FormPso : Form
    {
        public FormPso()
        {
            InitializeComponent();

            MyInit();
        }

        #region Event Handlers

        private void PanelMapPaint(object sender, PaintEventArgs e)
        {
            if (_swarm.Count > 0)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                for (int it = 0; it < _swarm.Count; ++it)
                {
                    if (Math.Abs(_swarm[it].X - 3) < panelMap.Width / 2 &&
                        Math.Abs(_swarm[it].Y - 3) < panelMap.Height / 2)
                        e.Graphics.FillEllipse(_brush, (float)_swarm[it].X - 3 + panelMap.Width / 2,
                            (float)_swarm[it].Y - 3 + panelMap.Height / 2, 6, 6);
                }
            }
        }

        private void ButtonGenerateClick(object sender, EventArgs e)
        {
            Generate();
            Buttons(true);
        }

        private void ButtonOptimalClick(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
            {
                Buttons(false);
                backgroundWorker.RunWorkerAsync(_swarm);
            }
        }

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy)
                backgroundWorker.CancelAsync();
        }

        private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 500; ++i)
            {
                switch (topolagyType)
                {
                    case ETopology.Full:
                        ((Swarm)e.Argument).SimulateStep(Delay.Value);
                        break;
                    case ETopology.Ring:
                        ((Swarm)e.Argument).SimulateStep(Delay.Value, 2);
                        break;
                    case ETopology.N4:
                        ((Swarm)e.Argument).SimulateStep(Delay.Value, 4);
                        break;
                }
                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                if (panelMap.InvokeRequired)
                {
                    panelMap.Invoke((MethodInvoker)(() => panelMap.Refresh()));
                }
                else
                {
                    panelMap.Refresh();
                }
            }
        }

        private void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            /*
            if (_solver.GetType() == typeof(OptimalSolver))
                toolStripStatusLabelOptimalVal.Text = _cost.ToString(CultureInfo.InvariantCulture);
            else
                toolStripStatusLabelCurrentVal.Text = _cost.ToString(CultureInfo.InvariantCulture);
            */
            double x = 0, y = 0, best = double.MaxValue;
            foreach (Particle p in _swarm.Particles)
            {
                if (best > p.Best)
                {
                    best = p.Best;
                    x = p.BestX;
                    y = p.BestY;
                }
            }
            toolStripStatusLabelBest.Text = best.ToString("N5");
            toolStripStatusLabelXval.Text = x.ToString("N5");
            toolStripStatusLabelYval.Text = y.ToString("N5");

            Buttons(true);
        }

        private void PointsToolStripMenuItem1Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog.Filter = "XML files (*.xml)|*.xml";
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                using (FileStream stream = File.OpenRead(openFileDialog.FileName))
                {
                    _swarm.Clear();
                    _swarm.AddRange((List<Particle>)_serializer.Deserialize(stream));
                    Buttons(true);
                }
                panelMap.Refresh();
            }
        }

        private void PointsToolStripMenuItemClick(object sender, EventArgs e)
        {
            saveFileDialog.InitialDirectory = Environment.CurrentDirectory;
            saveFileDialog.Filter = "XML files (*.xml)|*.xml";
            DialogResult result = saveFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                using FileStream stream = File.OpenWrite(saveFileDialog.FileName);
                _serializer.Serialize(stream, _swarm.Particles);
            }
        }


        private void ImageToolStripMenuItemClick(object sender, EventArgs e)
        {

            saveFileDialog.InitialDirectory = Environment.CurrentDirectory;
            saveFileDialog.Filter = "JPEG file (*.jpeg)|*.jpeg";
            DialogResult result = saveFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                using var bitmap = new Bitmap(panelMap.Width, panelMap.Height);
                panelMap.DrawToBitmap(bitmap, panelMap.ClientRectangle);
                bitmap.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private void RadioButtonFunction_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSphere.Checked)
            {
                functionType = EFunction.Sphere;
                return;
            }
            if (radioButtonGriewangk.Checked)
            {
                functionType = EFunction.Griewangk;
                return;
            }
            if (radioButtonRastrigin.Checked)
            {
                functionType = EFunction.Rastrigin;
                return;
            }
            if (radioButtonRosenbock.Checked)
            {
                functionType = EFunction.Rosenbock;
                return;
            }
        }
        private void RadioButtonAlgorithm_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonABase.Checked)
            {
                algorithmType = EAlgorithm.Base;
                return;
            }
            if (radioButtonAInit.Checked)
            {
                algorithmType = EAlgorithm.Weight;
                return;
            }
            if (radioButtonAConstr.Checked)
            {
                algorithmType = EAlgorithm.Constriction;
                return;
            }
        }

        private void RadioButtonTopo_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTFull.Checked)
            {
                topolagyType = ETopology.Full;
                return;
            }
            if (radioButtonTRing.Checked)
            {
                topolagyType = ETopology.Ring;
                return;
            }
            if (radioButtonT4.Checked)
            {
                topolagyType = ETopology.N4;
                return;
            }
        }

        private void ButtonSim_Click(object sender, EventArgs e)
        {
            Buttons(false);
            StringBuilder results = new();
            double[,] Fi = { { 1, 3 }, { 2, 2 }, { 3, 1 } };
            double x = 0, y = 0, best;
            List<Particle> particles = new(Population.Value);
            for (int particle = 0; particle < Population.Value; ++particle)
                particles.Add(new Particle(panelMap.Width, panelMap.Height));
            using (FileStream stream = File.OpenWrite("sim"))
            {
                _serializer.Serialize(stream, particles);
            }
            foreach (EFunction function in Enum.GetValues<EFunction>())
                foreach (EAlgorithm algorithm in Enum.GetValues<EAlgorithm>())
                    foreach (ETopology topology in Enum.GetValues<ETopology>())
                        for (int k = 0; k < Fi.GetLength(0); ++k)
                        {
                            best = double.MaxValue;
                            for (int i = 0; i < 10; ++i)
                            {
                                switch (algorithm)
                                {
                                    case EAlgorithm.Base:
                                        _swarm = new Swarm(function, Population.Value, Fi[k, 0], Fi[k, 1], 1d, 1d, panelMap.Width, panelMap.Height);
                                        break;
                                    case EAlgorithm.Weight:
                                        _swarm = new Swarm(function, Population.Value, Fi[k, 0], Fi[k, 1], 0.4, 1d, panelMap.Width, panelMap.Height);
                                        break;
                                    case EAlgorithm.Constriction:
                                        _swarm = new Swarm(function, Population.Value, Fi[k, 0], Fi[k, 1], 1d, 0.6d, panelMap.Width, panelMap.Height);
                                        break;
                                }
                                using (FileStream stream = File.OpenRead("sim"))
                                {
                                    _swarm.Clear();
                                    _swarm.AddRange((List<Particle>)_serializer.Deserialize(stream));
                                }
                                for (int j = 0; j < 500; ++j)
                                    switch (topology)
                                    {
                                        case ETopology.Full:
                                            _swarm.SimulateStep(Delay.Value);
                                            break;
                                        case ETopology.Ring:
                                            _swarm.SimulateStep(Delay.Value, 2);
                                            break;
                                        case ETopology.N4:
                                            _swarm.SimulateStep(Delay.Value, 4);
                                            break;
                                    }
                                foreach (Particle p in _swarm.Particles)
                                {
                                    if (best > p.Best)
                                    {
                                        best = p.Best;
                                        x = p.BestX;
                                        y = p.BestY;
                                    }
                                }
                            }
                            results.Append(function + "," + algorithm + "," + topology + "," + Fi[k, 0] + "," + Fi[k, 1] + "," + x.ToString("N4") + "," + y.ToString("N4") + "," + best.ToString("N4") + Environment.NewLine);
                        }
            File.WriteAllText("my.csv", results.ToString());
            Buttons(true);
        }

        #endregion

        #region My functions

        private void MyInit()
        {
            Population.Set(35, 20, 50);
            Delay.Set(0, 0, 1000);
        }

        private void Generate()
        {
            double fi1, fi2, psi, w = psi = 1;
            _swarm.Clear();
            if (double.TryParse(textBoxFi1.Text, out fi1) && double.TryParse(textBoxFi1.Text, out fi2))
            {
                if (algorithmType == EAlgorithm.Base ||
                    algorithmType == EAlgorithm.Weight && double.TryParse(textBoxFactor.Text, out w) ||
                    algorithmType == EAlgorithm.Constriction && double.TryParse(textBoxFactor.Text, out psi))
                {
                    _swarm = new Swarm(functionType, Population.Value, fi1, fi2, w, psi, panelMap.Width, panelMap.Height);
                    panelMap.Image = Swarm.Map;
                    panelMap.Refresh();
                }
            }
        }

        private void Buttons(bool enabled)
        {
            buttonOptimal.Enabled = buttonGenerate.Enabled = buttonSim.Enabled = enabled;
        }

        #endregion

        #region Data

        private readonly XmlSerializer _serializer = new(typeof(List<Particle>));
        private readonly Brush _brush = Brushes.Black;
        private Swarm _swarm = new();
        private EFunction functionType = EFunction.Sphere;
        private EAlgorithm algorithmType = EAlgorithm.Base;
        private ETopology topolagyType = ETopology.Full;

        #endregion
    }
}