using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Business.Dtos.Request.LanguageRequests;
using Core.Utilities.Results;
using NUnit.Framework.Internal;

namespace UnitTest
{
    public class LanguageTests
    {
        private readonly ILanguageService _languageService;
        private readonly IMapper _mapper;

        public LanguageTests(ILanguageService languageService, IMapper mapper)
        {
            _languageService = languageService;
            _mapper = mapper;
        }

        [Test]
        public void Add_WhenGivenLanguageName_ReturnsSuccessResult()
        {
            string languageName = "latince";
            var expectedResponse = new SuccessResult(Messages.LanguageAdded);

            var mappedLanguage = _mapper.Map<CreateLanguageRequest>(languageName);
            var result = _languageService.Add(mappedLanguage);

            Assert.AreEqual(expectedResponse, result.Result);


            Assert.Pass();
        }
    }
}