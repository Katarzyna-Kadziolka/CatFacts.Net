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
        public async Task GetRandomFactAsync_WithoutArguments_ShouldReturnRandomFact() {
            // Arrange
            CatFactsClient client = new CatFactsClient();
            // Act
            List<Fact> fact = await client.GetRandomFactAsync();
            // Assert
            fact[0].Used.Should().NotBeNull();
            fact[0].Source.Should().NotBeNull();
            fact[0].Type.Should().NotBeNull();
            fact[0].Deleted.Should().NotBeNull();
            fact[0].Id.Should().NotBeNull();
            fact[0].__v.Should().NotBeNull();
            fact[0].Text.Should().NotBeNull();
            fact[0].UpdatedAt.Should().NotBeNull();
            fact[0].CreatedAt.Should().NotBeNull();
            fact[0].User.Should().NotBeNull();

            if (fact[0].Status != null) {
                fact[0].Status.SentCount.Should().NotBeNull();
                fact[0].Status.Verified.Should().NotBeNull();
            }
            // tak do wszystkich, sprawdzam czy nie nulle
        }

        [Test]
        public async Task GetRandomFactAsync_CatTypeArgument_ShouldFact() {
            // Arrange
            CatFactsClient client = new CatFactsClient();
            // Act
            List<Fact> fact = await client.GetRandomFactAsync("dog");
            // Assert
            fact[0].Used.Should().NotBeNull();
            fact[0].Source.Should().NotBeNull();
            fact[0].Type.Should().Be("dog");
            fact[0].Deleted.Should().NotBeNull();
            fact[0].Id.Should().NotBeNull();
            fact[0].__v.Should().NotBeNull();
            fact[0].Text.Should().NotBeNull();
            fact[0].UpdatedAt.Should().NotBeNull();
            fact[0].CreatedAt.Should().NotBeNull();
            fact[0].User.Should().NotBeNull();

            if (fact[0].Status != null) {
                fact[0].Status.SentCount.Should().NotBeNull();
                fact[0].Status.Verified.Should().NotBeNull();
            }
        }
    }
}