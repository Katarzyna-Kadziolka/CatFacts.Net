using System;
using System.Threading.Tasks;
using CatFacts.Net;
using CatFacts.Net.Models;
using NUnit.Framework;
using FluentAssertions;


namespace CatFactsClientTests {
    public class Tests {
        [Test]
        public void Constructor_ShouldCreateClient() {
            // Arrange
            // Act
            CatFactsClient _ = new CatFactsClient();
            // Assert
        }

        [Test]
        public async Task GetRandomFactsAsync_WithoutArguments_ShouldReturnRandomFact() {
            // Arrange
            CatFactsClient client = new CatFactsClient();
            // Act
            Fact[] facts = await client.GetRandomFactsAsync();
            facts.Should().NotBeEmpty();
            Fact firstFact = facts[0];

            // Assert
            firstFact.Used.Should().NotBeNull();
            firstFact.Source.Should().NotBeNull();
            firstFact.Type.Should().NotBeNull();
            firstFact.Deleted.Should().NotBeNull();
            firstFact.Id.Should().NotBeNull();
            firstFact.Version.Should().NotBeNull();
            firstFact.Text.Should().NotBeNull();
            firstFact.UpdatedAt.Should().NotBeNull();
            firstFact.CreatedAt.Should().NotBeNull();
            firstFact.User.Should().NotBeNull();

            if (firstFact.Status != null) {
                firstFact.Status.SentCount.Should().NotBeNull();
                firstFact.Status.Verified.Should().NotBeNull();
            }
        }

        [Test]
        public async Task GetRandomFactsAsync_HorseTypeArgument_ShouldReturnRandomFact() {
            // Arrange
            CatFactsClient client = new CatFactsClient();
            // Act
            Fact[] facts = await client.GetRandomFactsAsync("horse");
            facts.Should().NotBeEmpty();
            Fact firstFact = facts[0];

            // Assert
            firstFact.Used.Should().NotBeNull();
            firstFact.Source.Should().NotBeNull();
            firstFact.Type.Should().Be("horse");
            firstFact.Deleted.Should().NotBeNull();
            firstFact.Id.Should().NotBeNull();
            firstFact.Version.Should().NotBeNull();
            firstFact.Text.Should().NotBeNull();
            firstFact.UpdatedAt.Should().NotBeNull();
            firstFact.CreatedAt.Should().NotBeNull();
            firstFact.User.Should().NotBeNull();

            if (firstFact.Status != null) {
                firstFact.Status.SentCount.Should().NotBeNull();
                firstFact.Status.Verified.Should().NotBeNull();
            }
        }

        [Test]
        public async Task GetRandomFactsAsync_AmountFive_ShouldReturnFiveFacts() {
            // Arrange
            CatFactsClient client = new CatFactsClient();

            // Act
            Fact[] facts = await client.GetRandomFactsAsync(amount: 5);

            // Assert
            facts.Should().NotBeEmpty();
            facts.Should().HaveCount(5);
        }

        [Test]
        public async Task GetRandomFactsAsync_AmountMoreThanFiveHundred_ShouldThrowArgumentOutOfRangeException() {
            // Arrange
            CatFactsClient client = new CatFactsClient();
            var amount = 501;

            // Act
            Func<Task> act = async () => { await client.GetRandomFactsAsync(amount: amount); };

            // Assert
            await act.Should().ThrowAsync<ArgumentOutOfRangeException>()
                .WithMessage($"Amount must be between 1 and 500. Got {amount}. (Parameter 'amount')");
        }

        [Test]
        public async Task GetRandomFactsAsync_AmountLessThanOne_ShouldThrowArgumentOutOfRangeException() {
            // Arrange
            CatFactsClient client = new CatFactsClient();
            var amount = 0;

            // Act
            Func<Task> act = async () => { await client.GetRandomFactsAsync(amount: amount); };

            // Assert
            await act.Should().ThrowAsync<ArgumentOutOfRangeException>()
                .WithMessage($"Amount must be between 1 and 500. Got {amount}. (Parameter 'amount')");
        }

        [Test]
        public async Task GetFactAsync_id591f98803b90f7150a19c229_ShouldReturnFact() {
            // Arrange
            CatFactsClient client = new CatFactsClient();
            string id = "591f98803b90f7150a19c229";

            // Act
            Fact? fact = await client.GetFactAsync(id);

            //Assert
            fact.Should().NotBeNull();
            fact!.Used.Should().NotBeNull();
            fact.Source.Should().NotBeNull();
            fact.Type.Should().NotBeNull();
            fact.Deleted.Should().NotBeNull();
            fact.Id.Should().Be(id);
            fact.Version.Should().NotBeNull();
            fact.Text.Should().NotBeNull();
            fact.UpdatedAt.Should().NotBeNull();
            fact.CreatedAt.Should().NotBeNull();
            fact.User.Should().NotBeNull();

            if (fact.Status != null) {
                fact.Status.SentCount.Should().NotBeNull();
                fact.Status.Verified.Should().NotBeNull();
            }
        }

        [Test]
        public async Task GetFactAsync_IdNotExisting_ShouldReturnNull() {
            // Arrange
            CatFactsClient client = new CatFactsClient();
            string id = "blablabla";

            // Act
            Fact? fact = await client.GetFactAsync(id);

            //Assert
            fact.Should().BeNull();
        }

        [Test]
        public async Task GetQueuedFactsAsync_WithoutArguments_ShouldReturnFacts() {
            // Arrange
            CatFactsClient client = new CatFactsClient();
            // Act
            UserSubmittedFacts facts = await client.GetQueuedFactsAsync();

            // Assert
            facts.Should().NotBeNull();
            facts.All.Should().NotBeNull();
            foreach (var fact in facts.All!) {
                fact.Id.Should().NotBeNull();
                fact.Text.Should().NotBeNull();
                fact.Type.Should().NotBeNull();
                fact.Upvotes.Should().NotBeNull();
                if (fact.User != null) {
                    fact.User.Id.Should().NotBeNull();
                    fact.User.Name.Should().NotBeNull();
                    fact.User.Name!.First.Should().NotBeNull();
                    fact.User.Name.Last.Should().NotBeNull();
                }
            }

            if (facts.UserAddedFacts != null) {
                foreach (var fact in facts.UserAddedFacts) {
                    fact.Id.Should().NotBeNull();
                    fact.Text.Should().NotBeNull();
                    fact.Type.Should().NotBeNull();
                    fact.Used.Should().NotBeNull();
                    fact.Upvotes.Should().NotBeNull();
                    fact.UserUpvoted.Should().NotBeNull();
                }
            }
        }

        [Test]
        public async Task GetQueuedFactsAsync_AnimalTypeDog_ShouldReturnFacts() {
            // Arrange
            CatFactsClient client = new CatFactsClient();
            // Act
            UserSubmittedFacts facts = await client.GetQueuedFactsAsync("dog");

            // Assert
            facts.Should().NotBeNull();
            facts.All.Should().NotBeNull();
            foreach (var fact in facts.All!) {
                fact.Id.Should().NotBeNull();
                fact.Text.Should().NotBeNull();
                fact.Type.Should().Be("dog");
                fact.Upvotes.Should().NotBeNull();
                if (fact.User != null) {
                    fact.User.Id.Should().NotBeNull();
                    fact.User.Name.Should().NotBeNull();
                    fact.User.Name!.First.Should().NotBeNull();
                    fact.User.Name.Last.Should().NotBeNull();
                }
            }

            if (facts.UserAddedFacts != null) {
                foreach (var fact in facts.UserAddedFacts) {
                    fact.Id.Should().NotBeNull();
                    fact.Text.Should().NotBeNull();
                    fact.Type.Should().Be("dog");
                    fact.Used.Should().NotBeNull();
                    fact.Upvotes.Should().NotBeNull();
                    fact.UserUpvoted.Should().NotBeNull();
                }
            }
        }
    }
}