namespace BusyList
{
    public enum PriorityEnum
    {
        Low,
        Medium,
        High
    }

    public static class PrioritySelect
    {
        public static PriorityEnum? SelectPriority(string priority)
        {
            
            switch (priority.ToLower())
            {
                case "l" or "low":
                    return PriorityEnum.Low;
                case "m" or "medium":
                    return PriorityEnum.Medium;
                case "h" or "high":
                    return PriorityEnum.High;
            }

            return null;
        }
    }
}
