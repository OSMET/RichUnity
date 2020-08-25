using System.Collections.Generic;
using RichUnity.Containers;
using RichUnity.StringUtils;

namespace RichUnity.SceneUtils
{
    public static class SceneEntityFinder
    {
        public static TEntity Find<TEntity, TValue>(List<TEntity> sceneEntities, string sceneName)
            where TEntity : SceneEntity<TValue>
        {
            for (int index = 0; index < sceneEntities.Count; index++)
            {
                var sceneEntity = sceneEntities[index];

                if (sceneName.CompareBy(sceneEntity.SearchString, sceneEntity.SceneNameSearchType))
                {
                    return sceneEntity;
                }
            }

            return null;
        }

        public static TEntity Find<TEntity, TValue>(RuntimeSet<TEntity> sceneEntities, string sceneName)
            where TEntity : SceneEntity<TValue>
        {
            return Find<TEntity, TValue>(sceneEntities.Items, sceneName);
        }
    }
}