namespace USG_Anormaly_Server.Models.db
{
    public class DbInitializer
    {
        public static void Initialize(usg_anormaly_mvi_systemContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (!context.TblTrainingStatusDetails.Any())
            {
                var status = new TblTrainingStatusDetail[]
                {
                    new TblTrainingStatusDetail
                    {
                        //StatusId = 1,
                        StatusDetail = "In Queue",
                        UpdateDate = DateTime.Now,
                        Activeflag = true,
                    },
                    new TblTrainingStatusDetail
                    {
                        //StatusId = 2,
                        StatusDetail = "On Training",
                        UpdateDate = DateTime.Now,
                        Activeflag = true,
                    },
                    new TblTrainingStatusDetail
                    {
                        //StatusId = 3,
                        StatusDetail = "Finished",
                        UpdateDate = DateTime.Now,
                        Activeflag = true,
                    },
                    new TblTrainingStatusDetail
                    {
                        //StatusId = 4,
                        StatusDetail = "Error",
                        UpdateDate = DateTime.Now,
                        Activeflag = true,
                    }
                };
                foreach (var s in status)
                {
                    context.TblTrainingStatusDetails.Add(s);
                }
                context.SaveChanges();
            }



        }
    }
}
