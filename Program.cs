using System;
using ZOSAPI;

namespace CSharpUserOperandApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Find the installed version of OpticStudio
            bool isInitialized = ZOSAPI_NetHelper.ZOSAPI_Initializer.Initialize();
            // Note -- uncomment the following line to use a custom initialization path
            //bool isInitialized = ZOSAPI_NetHelper.ZOSAPI_Initializer.Initialize(@"C:\Program Files\OpticStudio\");
            if (isInitialized)
            {
                LogInfo("Found OpticStudio at: " + ZOSAPI_NetHelper.ZOSAPI_Initializer.GetZemaxDirectory());
            }
            else
            {
                HandleError("Failed to locate OpticStudio!");
                return;
            }

            BeginUserOperand();
        }

        static void BeginUserOperand()
        {
            // Create the initial connection class
            ZOSAPI_Connection TheConnection = new ZOSAPI_Connection();

            // Attempt to connect to the existing OpticStudio instance
            IZOSAPI_Application TheApplication = null;
            try
            {
                TheApplication = TheConnection.ConnectToApplication(); // this will throw an exception if not launched from OpticStudio
            }
            catch (Exception ex)
            {
                HandleError(ex.Message);
                return;
            }
            if (TheApplication == null)
            {
                HandleError("An unknown connection error occurred!");
                return;
            }

            // Check the connection status
            if (!TheApplication.IsValidLicenseForAPI)
            {
                HandleError("Failed to connect to OpticStudio: " + TheApplication.LicenseStatus);
                return;
            }
            if (TheApplication.Mode != ZOSAPI_Mode.Operand)
            {
                HandleError("User plugin was started in the wrong mode: expected Operand, found " + TheApplication.Mode.ToString());
                return;
            }

            // Read the operand arguments
            double Hx = TheApplication.OperandArgument1;
            double Hy = TheApplication.OperandArgument2;
            double Px = TheApplication.OperandArgument3;
            double Py = TheApplication.OperandArgument4;

            // Initialize the output array
            int maxResultLength = TheApplication.OperandResults.Length;
            double[] operandResults = new double[maxResultLength];

            IOpticalSystem TheSystem = TheApplication.PrimarySystem;
            // Add your custom code here...

            int surf1 = (int)TheApplication.OperandArgument1;
            int surf2 = (int)TheApplication.OperandArgument2;

            ZOSAPI.Editors.LDE.ILDERow surf;

            // surf = TheSystem.LDE.GetSurfaceAt(surf1);
            // double rad1 = surf.Radius;

            // surf = TheSystem.LDE.GetSurfaceAt(surf2);
            // double rad2 = surf.Radius;

            // double shapeFactor = (rad1 + rad2) / (rad2 - rad1);

            // double operandValue = Math.Abs(shapeFactor - shapeFactor * Math.Abs(shapeFactor));

            operandResults[0] = 0;

            // Clean up
            FinishUserOperand(TheApplication, operandResults);
        }

        static void FinishUserOperand(IZOSAPI_Application TheApplication, double[] resultData)
        {
            // Note - OpticStudio will wait for the operand to complete until this application exits 
            if (TheApplication != null)
            {
                TheApplication.OperandResults.WriteData(resultData.Length, resultData);
            }
        }

        static void LogInfo(string message)
        {
            // TODO - add custom logging
            Console.WriteLine(message);
        }

        static void HandleError(string errorMessage)
        {
            // TODO - add custom error handling
            throw new Exception(errorMessage);
        }

    }
}
