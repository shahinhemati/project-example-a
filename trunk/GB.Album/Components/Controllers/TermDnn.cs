using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Entities.Content;
using DotNetNuke.Entities.Content.Common;
using DotNetNuke.Entities.Content.Taxonomy;
using GB.Album.Components.Entities;
using GB.Album.Entities;

namespace GB.Album.Components.Controllers
{
    public class TermDnn
    {

        /// <summary>
        /// This should run only after the post has been added/updated in data store and the ContentItem exists.
        /// </summary>
        /// <param name="objPost">The content item we are associating categories with. In this module, it will always be a question (first post).</param>
        /// <param name="objContent"></param>
        public void ManageQuestionTerms(AlbumInfo objAlbum, ContentItem objContent)
        {
            RemoveQuestionTerms(objContent);
            var terms = Util.GetContentController().GetContentItem(objAlbum.TabID).Terms;
            foreach (var term in terms)
            {
                Util.GetTermController().AddTermToContent(term, objContent);
            }
        }

        /// <summary>
        /// Removes terms associated w/ a specific ContentItem.
        /// </summary>
        /// <param name="objContent"></param>
        public void RemoveQuestionTerms(ContentItem objContent)
        {
            Util.GetTermController().RemoveTermsFromContent(objContent);
        }

        /// <summary>
        /// This method will check the core taxonomy to ensure that a term exists, if not it will create.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="vocabularyId"></param>
        /// <returns>The core 'Term'.</returns>
        public static Term CreateAndReturnTerm(string name, int vocabularyId)
        {
            var termController = Util.GetTermController();
            var existantTerm = termController.GetTermsByVocabulary(vocabularyId).Where(t => t.Name.ToLower() == name.ToLower()).FirstOrDefault();
            if (existantTerm != null)
            {
                return existantTerm;
            }

            var termId = termController.AddTerm(new Term(vocabularyId) { Name = name });
            return new Term { Name = name, TermId = termId };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vocabularyId"></param>
        /// <returns>The core 'Term'.</returns>
        public static Term GetTermById(int id, int vocabularyId)
        {
            var termController = Util.GetTermController();
            var existantTerm = termController.GetTermsByVocabulary(vocabularyId).Where(t => t.TermId == id).FirstOrDefault();
            return existantTerm;
        }
    }
}