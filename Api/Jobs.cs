namespace Api
{
    public static class Jobs
    {
        public static void OnJobCreating()
        {
            // Add daily jobs
            // RecurringJob.AddOrUpdate<IService>(x => x.Function(), CronDaily(8), TimeZoneInfo.Local)
        }
    }
}
