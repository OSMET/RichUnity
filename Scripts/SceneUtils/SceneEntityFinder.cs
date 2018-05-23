using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using RichUnity.Containers;

namespace RichUnity.SceneUtils
{
    public static class SceneEntityFinder
    {
        public static TEntity Find<TEntity, TValue>(List<TEntity> sceneEntities, string sceneName)
            where TEntity : SceneEntity<TValue>
        {
            var foundSceneEntity = sceneEntities.Find(sceneEntity =>
                sceneEntity.SceneNameSearchType == SceneEntitySearchType.Equals &&
                sceneName.Equals(sceneEntity.SearchString));

            if (foundSceneEntity == null)
            {
                foundSceneEntity = sceneEntities.Find(sceneEntity =>
                {
                    switch (sceneEntity.SceneNameSearchType)
                    {
                        case SceneEntitySearchType.StartsWith:
                            return sceneName.StartsWith(sceneEntity.SearchString);
                        case SceneEntitySearchType.EndsWith:
                            return sceneName.EndsWith(sceneEntity.SearchString);
                        case SceneEntitySearchType.Regex:
                            return Regex.IsMatch(sceneName, sceneEntity.SearchString);
                    }

                    return false;
                });
            }

            return foundSceneEntity;
        }

        public static TEntity Find<TEntity, TValue>(RuntimeSet<TEntity> sceneEntities, string sceneName)
            where TEntity : SceneEntity<TValue>
        {
            return Find<TEntity, TValue>(sceneEntities.ToList(), sceneName);
        }
        
        public static bool CompareBySearchType(string sceneName, string searchString, SceneEntitySearchType sceneEntitySearchType)
        {
            switch (sceneEntitySearchType)
            {
                case SceneEntitySearchType.Equals:
                    return sceneName.Equals(searchString);
                case SceneEntitySearchType.StartsWith:
                    return sceneName.StartsWith(searchString);
                case SceneEntitySearchType.EndsWith:
                    return sceneName.EndsWith(searchString);
                case SceneEntitySearchType.Regex:
                    return Regex.IsMatch(sceneName, searchString);
            }
            return false;
        }

        public static List<TEntity> FindAll<TEntity, TValue>(List<TEntity> sceneEntities, string sceneName)
            where TEntity : SceneEntity<TValue>
        {
            var foundSceneEntity = sceneEntities.FindAll(sceneEntity =>
            {
                switch (sceneEntity.SceneNameSearchType)
                {
                    case SceneEntitySearchType.Equals:
                        return sceneName.Equals(sceneEntity.SearchString);
                    case SceneEntitySearchType.StartsWith:
                        return sceneName.StartsWith(sceneEntity.SearchString);
                    case SceneEntitySearchType.EndsWith:
                        return sceneName.EndsWith(sceneEntity.SearchString);
                    case SceneEntitySearchType.Regex:
                        return Regex.IsMatch(sceneName, sceneEntity.SearchString);
                }
                return false;
            });
            return foundSceneEntity;
        }
        
        public static TEntity[] FindAll<TEntity, TValue>(TEntity[] sceneEntities, string sceneName)
            where TEntity : SceneEntity<TValue>
        {
            var foundSceneEntity = Array.FindAll(sceneEntities, sceneEntity =>
            {
                switch (sceneEntity.SceneNameSearchType)
                {
                    case SceneEntitySearchType.Equals:
                        return sceneName.Equals(sceneEntity.SearchString);
                    case SceneEntitySearchType.StartsWith:
                        return sceneName.StartsWith(sceneEntity.SearchString);
                    case SceneEntitySearchType.EndsWith:
                        return sceneName.EndsWith(sceneEntity.SearchString);
                    case SceneEntitySearchType.Regex:
                        return Regex.IsMatch(sceneName, sceneEntity.SearchString);
                }
                return false;
            });
            return foundSceneEntity;
        }
        
        public static List<TEntity> FindAll<TEntity, TValue>(RuntimeSet<TEntity> sceneEntities, string sceneName)
            where TEntity : SceneEntity<TValue>
        {
            return FindAll<TEntity, TValue>(sceneEntities.ToList(), sceneName);
        }
    }
}