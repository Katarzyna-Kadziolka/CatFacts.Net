using System;
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
        public async Task GetRandomFactAsync_WithoutArguments_ShouldReturnRandomFact() {
            // Arrange
            CatFactsClient client = new CatFactsClient();
            // Act
            Fact fact = await client.GetRandomFactAsync();
            // Assert
            fact.Used.Should().NotBeNull();
            // tak do wszystkich, sprawdzam czy nie nulle
        }

        [Test]
        public async Task GetRandomFactAsync_CatTypeArgument_ShouldFact() {
            // Arrange
            CatFactsClient client = new CatFactsClient();
            // Act
            Fact fact = await client.GetRandomFactAsync();
            // Assert
            fact.Should().BeOfType<Fact>();
        }
    }
}