using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerArrow : MonoBehaviour {
    private GameObject _following;

    [SerializeField]
    private float distanceToHide;
    private bool _startFollow;

    private SpriteRenderer arrowImage;
    
    public void StartPointing(GameObject objectToFollow) {
        arrowImage = GetComponentInChildren<SpriteRenderer>();
        _following = objectToFollow;
        _startFollow = true;
        if (objectToFollow.TryGetComponent<Enemy>(out Enemy enemy)) {
            enemy.OnEnemyDeath += EnemyToFollowOnOnEnemyDeath;
        }
    }

    private void EnemyToFollowOnOnEnemyDeath(object sender, EventArgs e) {
        DestroyArrow();
    }

    private void Update() {
        if (_startFollow) {
            if (Vector2.Distance(transform.position, _following.transform.position) < distanceToHide) {
                Hide();
            }
            else {
                float angle = Vector2.SignedAngle(Vector2.up, _following.transform.position - transform.position);
                transform.eulerAngles = new Vector3(0f, 0f, angle);
                Show();
            }
        }
    }

    private void DestroyArrow() {
        Destroy(gameObject);
    }

    private void Hide() {
        arrowImage.gameObject.SetActive(false);
    }

    private void Show() {
        arrowImage.gameObject.SetActive(true);
    }
}
