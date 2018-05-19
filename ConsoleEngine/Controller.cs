
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEngine.Engine
{

    /// <summary>
    /// Class to hold Control Detall
    /// </summary>
    public class Controls : IDisposable 
    {
        /// <summary>
        /// Task to check if conrtols typed
        /// </summary>
        Task ControllerTask;

        /// <summary>
        /// List of Controls to Check
        /// </summary>
        public List<Control> Gamecontrols;

        /// <summary>
        /// Is the controller Active
        /// </summary>
        public bool IsRunning { get; set; }

        /// <summary>
        /// Creates a control object with the task
        /// </summary>
        public Controls()
        {

            Gamecontrols = new List<Control>();


            ControllerTask = new Task(new Action(RunController));
        }

        /// <summary>
        /// Starts the Controller Task
        /// </summary>
        public void Activate()
        {
            ControllerTask.Start();

        }
        /// <summary>
        /// Pauses the Controller Task
        /// </summary>
        public void Deactivate()
        {
            IsRunning = false;
        }

        /// <summary>
        /// Main Controller Process
        /// </summary>
        private void RunController()
        {
            IsRunning = true;
            do
            {
            ConsoleKeyInfo keypress = new ConsoleKeyInfo();
            keypress = Console.ReadKey(true);
            foreach (Control  cont in Gamecontrols)
            {
               if (cont.KeyAssigned == keypress.Key)
                {
                    cont.FunctToRun.Invoke();

                }
            }
            } while (IsRunning == true); 
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        /// <summary>
        /// Destroy the task on destruction
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    ControllerTask.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Controls() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.

        /// <summary>
        /// Part of IDisposable
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }

    /// <summary>
    /// Class to hold indivual Controls
    /// </summary>
    public class Control
    {
        /// <summary>
        /// Creates a Control
        /// </summary>
        /// <param name="KeyToAssign">Key to watch</param>
        /// <param name="FuncttoRun">Action to take on key press</param>
        public Control(ConsoleKey KeyToAssign, Action FuncttoRun)
        {
            KeyAssigned = KeyToAssign;
            FunctToRun = FuncttoRun;
        }

        /// <summary>
        /// Key Press to watch for
        /// </summary>
        public ConsoleKey KeyAssigned { get; set; }

        /// <summary>
        /// Action to take when ket is pressed
        /// </summary>
        public Action FunctToRun { get; set; }
    }


}
