using System.Collections.Generic;
using System.Text.RegularExpressions;
using RichUnity.Containers;

namespace RichUnity.SceneUtils
{
    public static class SceneEntityFinder
    {
        public static TEntity Find<TEntity, TValue>(List<TEntity> sceneEntities, string sceneName) where TEntity : SceneEntity<TValue>
        {
            var foundSceneEntity = sceneEntities.Find(sceneEntity =>
                sceneEntity.SceneNameSearchType == SceneEntitySearchType.Equals &&
                sceneName.Equals(sceneEntity.SearchString));

            if (foundSceneEntity == null)
            {
                foundSceneEntity = sceneEntities.Find(sceneEntity =>
                {
                    if (sceneEntity.SceneNameSearchType == SceneEntitySearchType.StartsWith)
                    {
                        return sceneName.StartsWith(sceneEntity.SearchString);
                    }

                    if (sceneEntity.SceneNameSearchType == SceneEntitySearchType.EndsWith)
                    {
                        return sceneName.EndsWith(sceneEntity.SearchString);
                    }

                    if (sceneEntity.SceneNameSearchType == SceneEntitySearchType.Regex)
                    {
                        return Regex.IsMatch(sceneName, sceneEntity.SearchString);
                    }

                    return false;
                });
            }

            return foundSceneEntity;
        }


        public static TEntity Find<TEntity, TValue>(RuntimeSet<TEntity> sceneEntities, string sceneName) where TEntity : SceneEntity<TValue>
        {
            return Find<TEntity, TValue>(sceneEntities.ToList(), sceneName);
        }
    }
    
    
    
}