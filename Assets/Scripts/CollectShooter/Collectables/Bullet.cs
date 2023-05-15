using System;
using CollectShooter.Teams;
using DG.Tweening;
using GameCore.Data;
using GameCore.Player;
using UnityEngine;

namespace CollectShooter.Collectables
{
    public class Bullet : MonoBehaviour, IBackpackItem
    {
        public BulletEntity entity;

        private void Start()
        {
            entity.pickableItem.IsPickable = true;
        }

        public void SetTeam(Team team)
        {
            entity.team = team;
#if UNITY_EDITOR
            if(Application.isPlaying)
                UpdateTeamMaterial();
#else
            UpdateTeamMaterial();
#endif
        }

        public void UpdateTeamMaterial()
        {
            entity.renderer.sharedMaterial = GlobalContainer.TeamVisualRepository.GetMaterial(entity.team);
        }
        
        public void Collect(Transform parent, Vector3 localPosition, float scaleFactor, Action onEnd)
        {
            entity.pickableItem.IsPickable = false;
            entity.collider.enabled = false;
            if (entity.particles != null)
            {
                entity.particles.transform.parent = transform.parent;
                entity.particles.Play();
            }

            var movable = entity.movable;
            var settings = entity.settings;
            movable.parent = parent;
            movable.localEulerAngles = settings.rotationInPack;
            movable.transform.localScale = Vector3.zero;
            movable.localPosition = localPosition;
            movable.DOScale(settings.scaleInPack * scaleFactor, settings.flyTime);
            // movable.DOLocalMove(localPosition, settings.flyTime).OnComplete(() => {onEnd.Invoke();});
        }

        public void FlyTo(ItemFlyArgs args)
        {
            var movable = entity.movable;
            var settings = entity.settings;
            movable.parent = args.parent;
            movable.localEulerAngles = settings.rotationInPack;
            movable.DOLocalRotate((args.localRotation * entity.settings.rotationInPack), 
                args.moveTime);
            movable.DOLocalMove(args.localPosition, args.moveTime)
                .OnComplete(() => { args.onDone.Invoke(); });
        }

        public float GetSize()
        {
            return entity.settings.realSize;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

#if UNITY_EDITOR
        public void UpdateTeamMaterial(TeamVisualRepository visualRepository)
        {
            entity.renderer.sharedMaterial = visualRepository.GetMaterial(entity.team);
        } 
        #endif
    }
}