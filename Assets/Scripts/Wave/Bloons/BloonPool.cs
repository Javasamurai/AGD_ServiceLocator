using System.Collections.Generic;
using ServiceLocator.Player;
using ServiceLocator.Sound;
using UnityEngine;
using ServiceLocator.Utilities;

/*  This script demonstrates the implementation of Object Pool design pattern.
 *  If you're interested in learning about Object Pooling, you can find
 *  a dedicated course on Outscal's website.
 *  Link: https://outscal.com/courses
 * */

namespace ServiceLocator.Wave.Bloon
{
    public class BloonPool : GenericObjectPool<BloonController>
    {
        private BloonView bloonPrefab;
        private List<BloonScriptableObject> bloonScriptableObjects;
        private Transform bloonContainer;
        private WaveService waveService;
        private SoundService soundService;
        private PlayerService playerService;

        public BloonPool(WaveScriptableObject waveScriptableObject, WaveService waveService, SoundService soundService, PlayerService playerService)
        {
            this.bloonPrefab = waveScriptableObject.BloonPrefab;
            this.bloonScriptableObjects = waveScriptableObject.BloonScriptableObjects;
            bloonContainer = new GameObject("Bloon Container").transform;
            this.waveService = waveService;
            this.soundService = soundService;
            this.playerService = playerService;
        }

        public BloonController GetBloon(BloonType bloonType)
        {
            BloonController bloon = GetItem();
            BloonScriptableObject scriptableObjectToUse = bloonScriptableObjects.Find(so => so.Type == bloonType);
            bloon.Init(scriptableObjectToUse);
            return bloon;
        }

        protected override BloonController CreateItem() => new BloonController(bloonPrefab, bloonContainer, waveService, soundService, playerService);
    }
}