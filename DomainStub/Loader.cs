using System;
using System.IO;

namespace DomainStub
{
    public static class Loader
    {
        const string APP_NAME = "Bloodstream";
        public static int Run(string dllPath)
        {
            var ParentDirectory = Path.GetDirectoryName(dllPath);

            AppDomain newDomain = null;
            try
            {
                var setupInfo = new AppDomainSetup() { ApplicationBase = ParentDirectory, PrivateBinPath = ParentDirectory };
                newDomain = AppDomain.CreateDomain(APP_NAME, AppDomain.CurrentDomain.Evidence, setupInfo);

                return newDomain.ExecuteAssembly(Path.Combine(ParentDirectory, Path.ChangeExtension(APP_NAME, "exe")));
            }
            catch (Exception e)
            {
                File.WriteAllText(Path.Combine(ParentDirectory, "Logs", "LoaderCrash.log"), e.ToString());
            }
            finally
            {
                if (newDomain != null)
                    AppDomain.Unload(newDomain);
            }

            return -1;
        }
    }
}