﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Octokit
{
    /// <summary>
    /// A client for GitHub's Repository Statistics API.
    /// Note that the GitHub API uses caching on these endpoints,
    /// see <a href="https://developer.github.com/v3/repos/statistics/#a-word-about-caching">a word about caching</a> for more details.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developer.github.com/v3/repos/statistics/">Repository Statistics API documentation</a> for more information.
    /// </remarks>
    public class StatisticsClient : ApiClient, IStatisticsClient
    {
        /// <summary>
        /// Instantiates a new GitHub Statistics API client.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public StatisticsClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        /// <summary>
        /// Returns a list of <see cref="Contributor"/> for the given repository
        /// </summary>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        [ManualRoute("GET", "/repos/{owner}/{repo}/stats/contributors")]
        public Task<IReadOnlyList<Contributor>> GetContributors(string owner, string name)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, nameof(owner));
            Ensure.ArgumentNotNullOrEmptyString(name, nameof(name));

            return GetContributors(owner, name, CancellationToken.None);
        }

        /// <summary>
        /// Returns a list of <see cref="Contributor"/> for the given repository
        /// </summary>
        /// <param name="repositoryId">The Id of the repository</param>
        [ManualRoute("GET", "/repositories/{id}/stats/contributors")]
        public Task<IReadOnlyList<Contributor>> GetContributors(long repositoryId)
        {
            return GetContributors(repositoryId, CancellationToken.None);
        }

        /// <summary>
        /// Returns a list of <see cref="Contributor"/> for the given repository
        /// </summary>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        /// <param name="cancellationToken">A token used to cancel this potentially long running request</param>
        [ManualRoute("GET", "/repos/{owner}/{repo}/stats/contributors")]
        public Task<IReadOnlyList<Contributor>> GetContributors(string owner, string name, CancellationToken cancellationToken)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, nameof(owner));
            Ensure.ArgumentNotNullOrEmptyString(name, nameof(name));

            return ApiConnection.GetQueuedOperation<Contributor>(ApiUrls.StatsContributors(owner, name), cancellationToken);
        }

        /// <summary>
        /// Returns a list of <see cref="Contributor"/> for the given repository
        /// </summary>
        /// <param name="repositoryId">The Id of the repository</param>
        /// <param name="cancellationToken">A token used to cancel this potentially long running request</param>
        [ManualRoute("GET", "/repositories/{id}/stats/contributors")]
        public Task<IReadOnlyList<Contributor>> GetContributors(long repositoryId, CancellationToken cancellationToken)
        {
            return ApiConnection.GetQueuedOperation<Contributor>(ApiUrls.StatsContributors(repositoryId), cancellationToken);
        }

        /// <summary>
        /// Returns the last year of commit activity grouped by week.
        /// </summary>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        [ManualRoute("GET", "/repos/{owner}/{repo}/stats/commit_activity")]
        public Task<CommitActivity> GetCommitActivity(string owner, string name)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, nameof(owner));
            Ensure.ArgumentNotNullOrEmptyString(name, nameof(name));

            return GetCommitActivity(owner, name, CancellationToken.None);
        }

        /// <summary>
        /// Returns the last year of commit activity grouped by week.
        /// </summary>
        /// <param name="repositoryId">The Id of the repository</param>
        [ManualRoute("GET", "/repositories/{id}/stats/commit_activity")]
        public Task<CommitActivity> GetCommitActivity(long repositoryId)
        {
            return GetCommitActivity(repositoryId, CancellationToken.None);
        }

        /// <summary>
        /// Returns the last year of commit activity grouped by week.
        /// </summary>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        /// <param name="cancellationToken">A token used to cancel this potentially long running request</param>
        [ManualRoute("GET", "/repos/{owner}/{repo}/stats/commit_activity")]
        public async Task<CommitActivity> GetCommitActivity(string owner, string name, CancellationToken cancellationToken)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, nameof(owner));
            Ensure.ArgumentNotNullOrEmptyString(name, nameof(name));

            var activity = await ApiConnection.GetQueuedOperation<WeeklyCommitActivity>(ApiUrls.StatsCommitActivity(owner, name), cancellationToken).ConfigureAwait(false);
            return new CommitActivity(activity);
        }

        /// <summary>
        /// Returns the last year of commit activity grouped by week.
        /// </summary>
        /// <param name="repositoryId">The Id of the repository</param>
        /// <param name="cancellationToken">A token used to cancel this potentially long running request</param>
        [ManualRoute("GET", "/repositories/{id}/stats/commit_activity")]
        public async Task<CommitActivity> GetCommitActivity(long repositoryId, CancellationToken cancellationToken)
        {
            var activity = await ApiConnection.GetQueuedOperation<WeeklyCommitActivity>(ApiUrls.StatsCommitActivity(repositoryId), cancellationToken).ConfigureAwait(false);
            return new CommitActivity(activity);
        }

        /// <summary>
        /// Returns a weekly aggregate of the number of additions and deletions pushed to a repository.
        /// </summary>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        [ManualRoute("GET", "/repos/{owner}/{repo}/stats/code_frequency")]
        public Task<CodeFrequency> GetCodeFrequency(string owner, string name)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, nameof(owner));
            Ensure.ArgumentNotNullOrEmptyString(name, nameof(name));

            return GetCodeFrequency(owner, name, CancellationToken.None);
        }

        /// <summary>
        /// Returns a weekly aggregate of the number of additions and deletions pushed to a repository.
        /// </summary>
        /// <param name="repositoryId">The Id of the repository</param>
        [ManualRoute("GET", "/repositories/{id}/stats/code_frequency")]
        public Task<CodeFrequency> GetCodeFrequency(long repositoryId)
        {
            return GetCodeFrequency(repositoryId, CancellationToken.None);
        }

        /// <summary>
        /// Returns a weekly aggregate of the number of additions and deletions pushed to a repository.
        /// </summary>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        /// <param name="cancellationToken">A token used to cancel this potentially long running request</param>
        [ManualRoute("GET", "/repos/{owner}/{repo}/stats/code_frequency")]
        public async Task<CodeFrequency> GetCodeFrequency(string owner, string name, CancellationToken cancellationToken)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, nameof(owner));
            Ensure.ArgumentNotNullOrEmptyString(name, nameof(name));

            var rawFrequencies = await ApiConnection.GetQueuedOperation<long[]>(ApiUrls.StatsCodeFrequency(owner, name), cancellationToken).ConfigureAwait(false);
            return new CodeFrequency(rawFrequencies);
        }

        /// <summary>
        /// Returns a weekly aggregate of the number of additions and deletions pushed to a repository.
        /// </summary>
        /// <param name="repositoryId">The Id of the repository</param>
        /// <param name="cancellationToken">A token used to cancel this potentially long running request</param>
        [ManualRoute("GET", "/repositories/{id}/stats/code_frequency")]
        public async Task<CodeFrequency> GetCodeFrequency(long repositoryId, CancellationToken cancellationToken)
        {
            var rawFrequencies = await ApiConnection.GetQueuedOperation<long[]>(ApiUrls.StatsCodeFrequency(repositoryId), cancellationToken).ConfigureAwait(false);
            return new CodeFrequency(rawFrequencies);
        }

        /// <summary>
        /// Returns the total commit counts for the owner and total commit counts in total.
        /// </summary>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        [ManualRoute("GET", "/repos/{owner}/{repo}/stats/participation")]
        public Task<Participation> GetParticipation(string owner, string name)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, nameof(owner));
            Ensure.ArgumentNotNullOrEmptyString(name, nameof(name));

            return GetParticipation(owner, name, CancellationToken.None);
        }

        /// <summary>
        /// Returns the total commit counts for the owner and total commit counts in total.
        /// </summary>
        /// <param name="repositoryId">The Id of the repository</param>
        [ManualRoute("GET", "/repositories/{id}/stats/participation")]
        public Task<Participation> GetParticipation(long repositoryId)
        {
            return GetParticipation(repositoryId, CancellationToken.None);
        }

        /// <summary>
        /// Returns the total commit counts for the owner and total commit counts in total.
        /// </summary>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        /// <param name="cancellationToken">A token used to cancel this potentially long running request</param>
        [ManualRoute("GET", "/repos/{owner}/{repo}/stats/participation")]
        public async Task<Participation> GetParticipation(string owner, string name, CancellationToken cancellationToken)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, nameof(owner));
            Ensure.ArgumentNotNullOrEmptyString(name, nameof(name));

            var result = await ApiConnection.GetQueuedOperation<Participation>(ApiUrls.StatsParticipation(owner, name), cancellationToken).ConfigureAwait(false);
            return result.FirstOrDefault();
        }

        /// <summary>
        /// Returns the total commit counts for the owner and total commit counts in total.
        /// </summary>
        /// <param name="repositoryId">The Id of the repository</param>
        /// <param name="cancellationToken">A token used to cancel this potentially long running request</param>
        [ManualRoute("GET", "/repositories/{id}/stats/participation")]
        public async Task<Participation> GetParticipation(long repositoryId, CancellationToken cancellationToken)
        {
            var result = await ApiConnection.GetQueuedOperation<Participation>(ApiUrls.StatsParticipation(repositoryId), cancellationToken).ConfigureAwait(false);
            return result.FirstOrDefault();
        }

        /// <summary>
        /// Returns a list of the number of commits per hour in each day
        /// </summary>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        [ManualRoute("GET", "/repos/{owner}/{repo}/stats/punch_card")]
        public Task<PunchCard> GetPunchCard(string owner, string name)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, nameof(owner));
            Ensure.ArgumentNotNullOrEmptyString(name, nameof(name));

            return GetPunchCard(owner, name, CancellationToken.None);
        }

        /// <summary>
        /// Returns a list of the number of commits per hour in each day
        /// </summary>
        /// <param name="repositoryId">The Id of the repository</param>
        [ManualRoute("GET", "/repositories/{id}/stats/punch_card")]
        public Task<PunchCard> GetPunchCard(long repositoryId)
        {
            return GetPunchCard(repositoryId, CancellationToken.None);
        }

        /// <summary>
        /// Returns a list of the number of commits per hour in each day
        /// </summary>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        /// <param name="cancellationToken">A token used to cancel this potentially long running request</param>
        [ManualRoute("GET", "/repos/{owner}/{repo}/stats/punch_card")]
        public async Task<PunchCard> GetPunchCard(string owner, string name, CancellationToken cancellationToken)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, nameof(owner));
            Ensure.ArgumentNotNullOrEmptyString(name, nameof(name));

            var punchCardData = await ApiConnection.GetQueuedOperation<long[]>(ApiUrls.StatsPunchCard(owner, name), cancellationToken).ConfigureAwait(false);
            return new PunchCard(punchCardData);
        }

        /// <summary>
        /// Returns a list of the number of commits per hour in each day
        /// </summary>
        /// <param name="repositoryId">The Id of the repository</param>
        /// <param name="cancellationToken">A token used to cancel this potentially long running request</param>
        [ManualRoute("GET", "/repositories/{id}/stats/punch_card")]
        public async Task<PunchCard> GetPunchCard(long repositoryId, CancellationToken cancellationToken)
        {
            var punchCardData = await ApiConnection.GetQueuedOperation<long[]>(ApiUrls.StatsPunchCard(repositoryId), cancellationToken).ConfigureAwait(false);
            return new PunchCard(punchCardData);
        }
    }
}
