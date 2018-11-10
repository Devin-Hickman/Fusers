namespace Fusers
{
    /// <summary>
    /// Skills reperesent upgrades to a current tower. This struct tracks the current level of a skill, and the tier it belongs to in the tier tree
    /// The effects of a skill are defined inside the skill tree.
    /// </summary>
    public class AbstractSkill
    {
        private string skillName;
        private int currentLevel;
        private int maxLevel;
        private int tier;

        public AbstractSkill(int c, int m, int t, string s)
        {
            skillName = s;
            currentLevel = c;
            maxLevel = m;
            tier = t;
        }

        public void ResetCurrentLevelToZero()
        {
            currentLevel = 0;
        }

        public int GetCurrentLevel()
        {
            return currentLevel;
        }

        public int GetTier()
        {
            return tier;
        }

        public bool CurrentEqualsMaxLevel()
        {
            return (currentLevel == maxLevel);
        }

        public int RemoveAllSkillsLevels()
        {
            int pointRefund = currentLevel;
            currentLevel = 0;
            return pointRefund;
        }

        public int IncreaseCurrentLevel(int increment)
        {
            int extraPoints = 0;
            if (increment > 0)
            {
                if (increment + currentLevel <= maxLevel)
                {
                    currentLevel += increment;
                }
                else
                {
                    extraPoints = currentLevel - maxLevel + increment;
                    currentLevel = maxLevel;
                }
            }

            return extraPoints;
        }

        public int GetMaxLevel()
        {
            return maxLevel;
        }

        public string GetName()
        {
            return skillName;
        }
    }
}