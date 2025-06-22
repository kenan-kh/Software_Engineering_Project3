namespace LoanApp
{
    public class LoanEvaluator
    {
        // شروط الأهلية المباشرة
        private bool MeetsStrictEligibility(bool hasJob, int creditScore, int dependents) =>
            hasJob && creditScore >= 700 && dependents == 0;

        private bool MeetsHighScoreWithoutJob(bool hasJob, int creditScore, int income, bool ownsHouse) =>
            !hasJob && creditScore >= 750 && income > 5000 && ownsHouse;

        // شروط المراجعة اليدوية
        private bool MeetsModerateJobAndScore(bool hasJob, int creditScore, bool ownsHouse) =>
            hasJob && creditScore >= 600 && ownsHouse;

        private bool MeetsHighScoreWithDependents(bool hasJob, int creditScore, int dependents) =>
            hasJob && creditScore >= 700 && dependents >= 2;

        private bool MeetsLowScoreWithoutJob(bool hasJob, int creditScore, int dependents) =>
            !hasJob && creditScore >= 650 && dependents == 0;

        // شرط الدخل الأساسي
        private bool HasMinimumIncome(int income) => income >= 2000;

        private bool IsDirectlyEligible(bool hasJob, int creditScore, int income, int dependents, bool ownsHouse)
        {
            return MeetsStrictEligibility(hasJob, creditScore, dependents)
                || MeetsHighScoreWithoutJob(hasJob, creditScore, income, ownsHouse);
        }

        private bool NeedsManualReview(bool hasJob, int creditScore, int dependents, bool ownsHouse)
        {
            return MeetsModerateJobAndScore(hasJob, creditScore, ownsHouse)
                || MeetsHighScoreWithDependents(hasJob, creditScore, dependents)
                || MeetsLowScoreWithoutJob(hasJob, creditScore, dependents);
        }

        public string GetLoanEligibility(int income, bool hasJob, int creditScore, int dependents, bool ownsHouse)
        {
            if (!HasMinimumIncome(income))
                return "Not Eligible";

            if (IsDirectlyEligible(hasJob, creditScore, income, dependents, ownsHouse))
                return "Eligible";

            if (NeedsManualReview(hasJob, creditScore, dependents, ownsHouse))
                return "Review Manually";

            return "Not Eligible";
        }
    }
}
