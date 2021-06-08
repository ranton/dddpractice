using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainLogic
{
    public abstract class Strategy : Entity
    {
        public StrategyType StrategyType { get; protected set; }
        public string Title { get; protected set; }
        public string Summary { get; protected set; }        
        public IList<Material> Materials { get; protected set; }
        public Test Test { get; protected set; }
        public Version Version { get; protected set; }

        private Strategy()
        {
            this.Materials = new List<Material>();
        }

        public Strategy(StrategyType strategyType,
            string title,
            string summary,
            Test test,
            Version version) : this()
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Summary = summary ?? throw new ArgumentNullException(nameof(summary));

            StrategyType = strategyType;
            Test = test;
            Version = version ?? new Version(0, 1, 0);
        }
        

        public virtual void AddMaterial(Material material)
        {           
            if (material == null) throw new ArgumentException(nameof(material));

            this.Materials.Add(material);
        }
    }

    public class VideoStrategy : Strategy, ICanAddPreRequisite
    {
        public VideoStrategy(string title,
            string summary,
            Test test,
            Version version) : base(StrategyType.Video, title, summary, test, version)
        {}

        public IList<Strategy> PreRequisites { get; protected set; }
        public virtual void AddPreRequisite(Strategy strategy)
        {
            if (this == strategy) throw new ArgumentException(nameof(strategy));

            this.PreRequisites.Add(strategy);
        }
    }   

    public class ClassroomStrategy : Strategy, ICanAddPreRequisite
    {
        public ClassroomStrategy(string title,
            string summary,
            Test test,
            Version version) : base(StrategyType.Classroom, title, summary, test, version)
        { }
        public IList<Strategy> PreRequisites { get; protected set; }

        public void AddPreRequisite(Strategy strategy)
        {
            if (this == strategy) throw new ArgumentException(nameof(strategy));

            this.PreRequisites.Add(strategy);
        }
    }

    public class DocumentStrategy : Strategy
    {
        public DocumentStrategy(string title,
            string summary,
            Test test,
            Version version) : base(StrategyType.Document, title, summary, test, version)
        { }
    }


}
