namespace Liste
{
    public class Animal
    {
        public string _name;
        public int _age;
        /*
        public Animal(string name, int age)
        {
            _name = name;
            _age = age;
        }
        */
        public override string ToString()
        {
            return $"Name: {_name}\tAge: {_age}";
        }
    }
}