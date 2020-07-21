using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Common.Model;
using Common.Repository;
using Common.Utils;
using Common.XML;
using log4net;

namespace Common.XML
{
    public class GenerateXML
    {
        private readonly XMLCreateCRDE _xMLCreateCRDE;
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private int MaxActionsToRunInParallel_GenerateXML = ServiceConfiguration.MaxActionsToRunInParallel_GenerateXML;
        public GenerateXML()
        {
            _xMLCreateCRDE = new XMLCreateCRDE();
        }

        public void Handle()
        {
            _log.Info("trying Generate XML.");
            using (DBHelper db = new DBHelper())
            {
                Rep_ms_euc_cc_input Rep_ms_euc_cc_input = new Rep_ms_euc_cc_input(db);
                Rep_ms_euc_cc_sid_debitur rep_debitur = new Rep_ms_euc_cc_sid_debitur(db);
                List<euc_cc_input> listEucCcInput = Rep_ms_euc_cc_input.GetAll(string.Format("WHERE FLAG='0' order by CREATED_DATE"));
                int listInputCount = listEucCcInput.Count();
                if(listInputCount > 0)
                {
                    var stopWatch = Stopwatch.StartNew();
                    //using (DBHelper db = new DBHelper())
                    //{
                    //, new ParallelOptions { MaxDegreeOfParallelism = 100 }
                    ParallelOptions MaxParalel = new ParallelOptions();
                    MaxParalel.MaxDegreeOfParallelism = MaxActionsToRunInParallel_GenerateXML;
                    Parallel.ForEach(listEucCcInput, MaxParalel, input =>
                    //foreach (var item in listEucCcInput)
                    {
                        //  Console.WriteLine("Fruit Name: {0}, Thread Id= {1}", input, Thread.CurrentThread.ManagedThreadId);
                        _xMLCreateCRDE.Handle(input);
                    }
                   
                   );
                    _log.Info($"Parallel.ForEach() execution time = {stopWatch.Elapsed.TotalSeconds}");
                }
                else
                {
                    _log.Info($"list in tbl input count : {listInputCount}");
                }
                
            }
            
            //              Console.Read();
            //foreach (euc_cc_input oInput in listEucCcInput)
            //{
            //    _xMLCreateCRDE.Handle(oInput);
            //}
            //_log.Info($"Parallel.ForEach() execution time = {stopWatch.Elapsed.TotalSeconds}");
            // }
        }
    }
}

