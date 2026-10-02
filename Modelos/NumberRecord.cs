namespace Parcial_p4_LuisEnmanuel.Modelos;

    public record NumberRecord
    {
        public int Id {  get; set; }
        public string Fecha { get; set; } = string.Empty;
        public int Numero { get; set; }

        public int Resultado { get; set; }

    }

