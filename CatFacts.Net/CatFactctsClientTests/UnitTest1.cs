using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatFacts.Net;
using NUnit.Framework;
using FluentAssertions;


namespace CatFactsClientTests {
    public class Tests {
        [Test]
        public void Constructor_ShouldCreateClient() {
            // Arrange
            // Act
            CatFactsClient client = new CatFactsClient();
            // Assert
        }

        [Test]
        public async Task GetRandomFactsAsync_WithoutArguments_ShouldReturnRandomFact() {
            // Arrange
            CatFactsClient client = new CatFactsClient();
            // Act
            List<Fact> facts = await client.GetRandomFactsAsync();
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
        public async Task GetRandomFactsAsync_CatTypeArgument_ShouldReturnRandomFact() {
            // Arrange
            CatFactsClient client = new CatFactsClient();
            // Act
            List<Fact> facts = await client.GetRandomFactsAsync("horse");
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
            List<Fact> facts = await client.GetRandomFactsAsync(amount: 5);

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
            Func<Task> act = async () => {
                await client.GetRandomFactsAsync(amount: amount);
            };

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
            Func<Task> act = async () => {
                await client.GetRandomFactsAsync(amount: amount);
            };
            
            // Assert
            await act.Should().ThrowAsync<ArgumentOutOfRangeException>()
                .WithMessage($"Amount must be between 1 and 500. Got {amount}. (Parameter 'amount')");
        }
    }
}