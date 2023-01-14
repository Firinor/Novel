using System;

namespace FirParser
{
    public static class StringParser
    {
        public static T ParseTo<T>(string Name, bool ToLower = true) where T : System.Enum
        {
            var enume = typeof(T);

            var values = enume.GetEnumValues();

            foreach(var value in values)
            {
                if (ToLower)
                {
                    if(value.ToString().ToLower() == Name.ToLower())
                        return (T)value;
                }
                else
                {
                    if (value.ToString() == Name)
                        return (T)value;
                }
            }

            return default(T);
        }

        public static T1 NotSafeFindField<T1>(string Name, object Librari, bool ToLower = true) 
            where T1 : class
        {
            var classe = Librari.GetType();

            if (ToLower)
            {
                var values = classe.GetFields();

                string name = $"{typeof(T1).ToString().ToLower()} {Name.ToLower()}";

                foreach (var value in values)
                {
                    if (value.ToString().ToLower() == name)
                        return (T1)value.GetValue(Librari);
                }
            }
            else
            {
                try
                {
                    T1 result = (T1)classe.GetField(Name).GetValue(Librari);
                    return result;
                }
                catch
                {
                    //Exception below in the script
                }
            }

            throw new Exception($"Couldn't find in {classe} a field by string {Name}!");
            //return default(T1);
        }
    }
}
