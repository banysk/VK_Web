using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    /// <summary>
    /// Технология
    /// </summary>
    public class Tech
    {
        /// <summary>
        /// Id технологии
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Название технологии
        /// </summary>
        public string Name { get; set; }

        public Tech(string name)
        {
            Name = name;
        }

        [NotMapped]
        public static List<Tech> Default { get =>
            (
                new List<Tech>()
                {
                    new Tech("Artificial Intelligence"),
                    new Tech("Machine Learning"),
                    new Tech("Data Science & Analytics"),
                    new Tech("Data Engineering"),
                    new Tech("Data Visualization"),
                    new Tech("Cybersecurity"),
                    new Tech("Cybersecurity"),
                    new Tech("Cloud Computing/AWS"),
                    new Tech("Extended Reality"),
                    new Tech("Internet of Things (IoT)"),
                    new Tech("UI/UX Design"),
                    new Tech("Mobile Development"),
                    new Tech("Blockchain"),
                    new Tech("Quantum Computing"),
                    new Tech("Robotics"),
                    new Tech("Product Management"),
                    new Tech("Salesforce/CRMs"),
                    new Tech("Low-Code Platforms"),
                    new Tech("Programming Languages in General"),
                    new Tech("5G technology adoption"),
                    new Tech("Metaverse"),
                    new Tech("Clean technology"),
                }
            );}
    }
}
