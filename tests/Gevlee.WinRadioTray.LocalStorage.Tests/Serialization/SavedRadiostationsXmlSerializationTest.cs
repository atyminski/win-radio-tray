using System.Collections.Generic;
using System.IO;
using Gevlee.WinRadioTray.LocalStorage.Contract;
using Gevlee.WinRadioTray.LocalStorage.Serialization;
using Xunit;

namespace Gevlee.WinRadioTray.LocalStorage.Tests.Serialization
{
	public class SavedRadiostationsXmlSerializationTest
	{
		private IDictionary<string, SavedRadiostations> testSets;

		public SavedRadiostationsXmlSerializationTest()
		{
			InitializeSets();
		}

		private void InitializeSets()
		{
			testSets = new Dictionary<string, SavedRadiostations>
			{
				{
					"only_radiostations", new SavedRadiostations()
					{
						StandaloneRadiostations = new List<Radiostation>
						{
							new Radiostation()
							{
								Name = "TEST",
								Url = "http://test/test"
							}
						}
					}
				},
				{
					"only_groups", new SavedRadiostations()
					{
						RadiostationsGroups = new List<RadiostationsGroup>
						{
							new RadiostationsGroup("TEST_GROUP")
							{
								Radiostations = new List<Radiostation>(new[]
								{
									new Radiostation()
									{
										Name = "TEST1",
										Url = "http://test/test"
									},
									new Radiostation()
									{
										Name = "TEST2",
										Url = "http://test/test"
									},
								})
							},
							new RadiostationsGroup("TEST_GROUP_2")
							{
								Radiostations = new List<Radiostation>(new[]
								{
									new Radiostation()
									{
										Name = "TEST3",
										Url = "http://test/test"
									}
								})
							}
						}
					}
				},
				{
					"mix", new SavedRadiostations()
					{
						StandaloneRadiostations = new List<Radiostation>
						{
							new Radiostation()
							{
								Name = "TEST",
								Url = "http://test/test"
							}
						},
						RadiostationsGroups = new List<RadiostationsGroup>
						{
							new RadiostationsGroup("TEST_GROUP")
							{
								Radiostations = new List<Radiostation>(new[]
								{
									new Radiostation()
									{
										Name = "TEST1",
										Url = "http://test/test"
									},
									new Radiostation()
									{
										Name = "TEST2",
										Url = "http://test/test"
									},
								})
							},
							new RadiostationsGroup("TEST_GROUP_2")
							{
								Radiostations = new List<Radiostation>(new[]
								{
									new Radiostation()
									{
										Name = "TEST3",
										Url = "http://test/test"
									}
								})
							}
						}
					}
				}
			};
		}

		[InlineData("only_radiostations")]
		[InlineData("only_groups")]
		[InlineData("mix")]
		[Theory]
		public void Should_Serialize_Successfull(string testSet)
		{
			var serializer = new XmlSerializer<SavedRadiostations>();
			var fileContent = File.ReadAllText($"Serialization/TestData/{testSet}.xml");
			var result = serializer.SerializeToString(testSets[testSet]);
			Assert.Equal(fileContent, result);
		}

		[InlineData("only_radiostations")]
		[InlineData("only_groups")]
		[InlineData("mix")]
		[Theory]
		public void Should_Serialize_Successfull_Byte(string testSet)
		{
			var serializer = new XmlSerializer<SavedRadiostations>();
			var fileContent = File.ReadAllBytes($"Serialization/TestData/{testSet}.xml");
			var result = serializer.SerializeToByteArray(testSets[testSet]);
			Assert.Equal(fileContent, result);
		}

		[InlineData("only_radiostations")]
		[InlineData("only_groups")]
		[InlineData("mix")]
		[Theory]
		public void Should_Deserialize_Successfull(string testSet)
		{
			var serializer = new XmlSerializer<SavedRadiostations>();
			var fileContent = File.ReadAllText($"Serialization/TestData/{testSet}.xml");
			var result = serializer.DeserializeFromString(fileContent);
			Assert.Equal(testSets[testSet].RadiostationsGroups?.Count ?? 0, result.RadiostationsGroups?.Count ?? 0);
			Assert.Equal(testSets[testSet].StandaloneRadiostations?.Count ?? 0, result.StandaloneRadiostations?.Count ?? 0);
		}

		[InlineData("only_radiostations")]
		[InlineData("only_groups")]
		[InlineData("mix")]
		[Theory]
		public void Should_Deserialize_Successfull_Byte(string testSet)
		{
			var serializer = new XmlSerializer<SavedRadiostations>();
			var fileContent = File.ReadAllBytes($"Serialization/TestData/{testSet}.xml");
			var result = serializer.DeserializeFromByteArray(fileContent);
			Assert.Equal(testSets[testSet].RadiostationsGroups?.Count ?? 0, result.RadiostationsGroups?.Count ?? 0);
			Assert.Equal(testSets[testSet].StandaloneRadiostations?.Count ?? 0, result.StandaloneRadiostations?.Count ?? 0);
		}
	}
}