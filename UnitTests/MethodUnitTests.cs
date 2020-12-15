// ***********************************************************************
// Assembly         : JackHenryTwitter.Tests
// Author           : Chuck
// Created          : 12-05-2020
//
// Last Modified By : Chuck
// Last Modified On : 12-08-2020
// ***********************************************************************
// <copyright file="MethodUnitTests.cs" company="">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using JackHenryTwitter.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace JackHenryTwitter.Tests.UnitTests
{
    /// <summary>
    /// Defines test class MethodUnitTests.
    /// </summary>
    [TestClass]
    public class MethodUnitTests
    {
        GetTwitterDataFromJsonFile getData = new GetTwitterDataFromJsonFile();
        /// <summary>
        /// Defines the test method TestCheckForEmoji.
        /// </summary>
        [TestMethod]
        public void TestCheckForEmoji()
        {
            List<string> emojiString = new List<string>();
            emojiString.Add(@"mas tu é hetero 😔🤡💔");
            emojiString.Add(@"you are here 😔💔");
            emojiString.Add(@"you are here 🤡💔");
            List<EmojiBase> emojiList = JackHenryTwitter.Utilities.LineStatParsers.GetEmojiList(emojiString);
            Assert.IsTrue(emojiList.Count > 0);
        }

        [TestMethod]
        public void TestCheckForUrls()
        {
            List<string> urlString = new List<string>();
            urlString.Add(@"mas http://www.gmail.com tu é https://google.net hetero 😔🤡💔");
            urlString.Add(@"you http://criswells.gov are here 😔💔");
            urlString.Add(@"you https://fun.tv are http://verrygood.org here 🤡💔");
            //List<EmojiBase> emojiList = JackHenryTwitter.Utilities.LineStatParsers.GetUrlCount(urlString);
            int count = Utilities.LineStatParsers.GetTotalUrlCount(urlString);
            List<string> urlList = Utilities.LineStatParsers.GetUrlList(urlString); 
            Assert.IsTrue(count > 0);
        }

        /// <summary>
        /// Defines the test method TestSetPctTweetsWithPhoto.
        /// </summary>
        [TestMethod]
        public void TestSetPctTweetsWithPhoto()
        {
            Root root = getData.GetTweeterRootData();
            TweetStats stats = new TweetStats(root, new List<EmojiBase>(), new RunningTotals());
            stats.SetPctTweetsWithPhoto();
            Assert.IsTrue(stats.PctTweetsWithPhoto > 0);
        }

        /// <summary>
        /// Defines the test method TestSetPctTweetsWithUrl.
        /// </summary>
        [TestMethod]
        public void TestSetPctTweetsWithUrl()
        {
            Root root = getData.GetTweeterRootData();
            TweetStats stats = new TweetStats(root, new List<EmojiBase>(), new RunningTotals());
            stats.SetPctTweetsWithUrl();
            Assert.IsTrue(stats.PctTweetsWithUrl > 0);
        }

        /// <summary>
        /// Defines the test method TestSetTopHashtags.
        /// </summary>
        [TestMethod]
        public void TestSetTopHashtags()
        {
            Root root = getData.GetTweeterRootData();
            TweetStats stats = new TweetStats(root, new List<EmojiBase>(), new RunningTotals());
            stats.SetTopHashtags();
            Assert.IsTrue(stats.TopHashtagList.Count > 0);
        }

        /// <summary>
        /// Defines the test method TestSetTopUrlDomains.
        /// </summary>
        [TestMethod]
        public void TestSetTopUrlDomains()
        {
            Root root = getData.GetTweeterRootData();
            TweetStats stats = new TweetStats(root, new List<EmojiBase>(), new RunningTotals());
            stats.SetTopUrlDomains();
            Assert.IsTrue(stats.TopUrlDomainList.Count > 0);
        }

        /// <summary>
        /// Defines the test method TestTweetStatsSetAverageTimes.
        /// </summary>
        [TestMethod]
        public void TestTweetStatsSetAverageTimes()
        {
            TweetStats stats = new TweetStats();
            stats.TotalDownloadTimeInMiliSeconds = 10000;
            stats.TotalTweetsReceived = 139;
            stats.SetAverageTimes();
            Assert.IsTrue(stats.AverageTweetsReceivedPerSecond > 0);
        }
    }
}