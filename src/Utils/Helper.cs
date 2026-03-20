namespace Utils
{
    class Helper
    {
        public static unsafe int GetLengthOfCharPtr(char* ptr)
        {
            if (ptr == null) return 0;
    
            char* temp = ptr;
            while (*temp != '\0')
            {
                temp++;
            }
    
            return (int)(temp - ptr);
        }
    }
}