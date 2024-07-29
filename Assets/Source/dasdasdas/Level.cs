using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Source.CellManagement;
using Source.CellManagement.Mono;
using Source.Game;
using Source.Level.Mono;
using UnityEngine;
using VContainer;

namespace Source.Level
{
    public class Level
    {
        [Inject] private readonly CellsCreator sjqwejoiqwe;
        [Inject] private readonly ItemCreator jioqweijoeqwioj;
        [Inject] private readonly GameSettingsScriptable jweqkdsqlaksd;
        [Inject] private readonly LevelViewMono jioqwmkoqewmkewq;
        private readonly GameStats qweklqewkldas;

        private Vector2Int pokfewik = new Vector2Int(5, 7);
        private List<CellViewMono> djsiaodjais = new List<CellViewMono>();

        private List<CellViewMono> qwioejqwoi = new List<CellViewMono>();

        [Inject]
        private Level(GameStats qweklqewkldas)
        {
            this.qweklqewkldas = qweklqewkldas;
            CellViewMono.SIAOJDSJAIODJASI += CheckMergedCell;
            qweklqewkldas.ewioeqop += Generate;
            qweklqewkldas.QWIOEIJORIOJERWT += RemoveLevel;
        }

        private void Generate()
        {
            if (djsiaodjais.Count > 0)
            {
                foreach (var cellView in djsiaodjais)
                {
                    cellView.RemoveItem();
                }
            }
            else
            {
                jioqwmkoqewmkewq.Transform.position = new Vector2(
                                                    -jweqkdsqlaksd.LevelSize.x / 2f * jweqkdsqlaksd.CellSize.x + jweqkdsqlaksd.CellSize.x/2f,
                                                    -jweqkdsqlaksd.LevelSize.y / 2f * jweqkdsqlaksd.CellSize.y + jweqkdsqlaksd.CellSize.y/2f) + 
                                                jweqkdsqlaksd.LevelPosition;
                for (int i = 0; i < jweqkdsqlaksd.LevelSize.x; i++)
                {
                    for (int j = jweqkdsqlaksd.LevelSize.y; j > 0 ; j--)
                    {
                        if ((Mathf.Abs(i) >= jweqkdsqlaksd.LevelSize.x - jweqkdsqlaksd.BorderCut || 
                            Mathf.Abs(i) <= jweqkdsqlaksd.BorderCut - 1) && 
                            (Mathf.Abs(j) >= jweqkdsqlaksd.LevelSize.y - jweqkdsqlaksd.BorderCut + 1 ||
                            Mathf.Abs(j) <= jweqkdsqlaksd.BorderCut)) continue;
                        Vector2Int position = new Vector2Int(i, j);
                        CellViewMono cellViewMono = sjqwejoiqwe.Generate(position);
                        ItemMono itemMono = jioqweijoeqwioj.Get();
                        cellViewMono.Init(itemMono);
                    
                        djsiaodjais.Add(cellViewMono);
                    }
                }
            }
        }

        private void RemoveLevel()
        {
            for (int i = 0; i < djsiaodjais.Count; i++)
            {
                djsiaodjais[i].RemoveItem();
                GameObject.Destroy(djsiaodjais[i].gameObject);
            }
            djsiaodjais.Clear();
        }

        public void UpdateCells()
        {
            MoveItem();
            foreach (var cellView in djsiaodjais)
            {
                cellView.MoveItem();
            }
        }
        
        private void CheckMergedCell(CellViewMono cellViewMono)
        {
            qwioejqwoi.Clear();
            Vector2Int startPosition = cellViewMono.jdoisajiq;

            // Check horizontally
            CheckMergedDirection(startPosition, Vector2Int.right, cellViewMono);
            CheckMergedDirection(startPosition, Vector2Int.left, cellViewMono);

            // Check vertically
            CheckMergedDirection(startPosition, Vector2Int.up, cellViewMono);
            CheckMergedDirection(startPosition, Vector2Int.down, cellViewMono);

            if (qwioejqwoi.Count > 2)
            {
                int scoreMultiplier = jweqkdsqlaksd.ByItemScore ? cellViewMono.JAIODSAJIO.Index : 1;
                qweklqewkldas.AddScore(qwioejqwoi.Count * scoreMultiplier);
                jioqwmkoqewmkewq.PlayAudioMerge();
                foreach (var mergedCellView in qwioejqwoi)
                {
                    mergedCellView.RemoveItem();
                }
            }
            else
            {
                cellViewMono.ReturnCell();
            }
        }

        private void CheckMergedDirection(Vector2Int start, Vector2Int direction, CellViewMono originCell)
        {
            Vector2Int position = start;
            for (int i = 0; i < jweqkdsqlaksd.LevelSize.x + jweqkdsqlaksd.LevelSize.y; i++)
            {
                if (!IsInsideLevelBounds(position))
                    break;

                var findCell = djsiaodjais.FirstOrDefault(cell => cell.jdoisajiq == position);

                if (findCell != null && !findCell.DSJIOSADJIO && !originCell.DSJIOSADJIO && findCell.JAIODSAJIO.Index == originCell.JAIODSAJIO.Index)
                {
                    if (!qwioejqwoi.Contains(findCell))
                    {
                        qwioejqwoi.Add(findCell);
                    }
                }
                else
                {
                    break;
                }
                
                position += direction;
            }
        }

        private bool IsInsideLevelBounds(Vector2Int position)
        {
            return position.x >= 0 && position.x < jweqkdsqlaksd.LevelSize.x &&
                   position.y >= 0 && position.y < jweqkdsqlaksd.LevelSize.y;
        }
        
        private void CheckMergedCells()
        {
            foreach (var cellView in djsiaodjais)
            {
                CheckMergedCell(cellView);
            }
        }

        private void MoveItem()
        {
            foreach (var cellView in djsiaodjais)
            {
                Vector2Int movedPosition = cellView.jdoisajiq;
                movedPosition.y--;
                CellViewMono nextCellViewMono = djsiaodjais.FirstOrDefault(_ => movedPosition == _.jdoisajiq);
                if (nextCellViewMono && nextCellViewMono.DSJIOSADJIO)
                {
                    nextCellViewMono.Init(cellView.TakeItem());
                    SpawnNewItem();
                }
            }
        }

        private void SpawnNewItem()
        {
            foreach (var cellView in djsiaodjais)
            {
                if ((cellView.jdoisajiq.y >= jweqkdsqlaksd.LevelSize.y - jweqkdsqlaksd.BorderCut - 1 && 
                     (cellView.jdoisajiq.x >= jweqkdsqlaksd.LevelSize.x - jweqkdsqlaksd.BorderCut ||
                      cellView.jdoisajiq.x <= jweqkdsqlaksd.BorderCut) ||
                     cellView.jdoisajiq.y == jweqkdsqlaksd.LevelSize.y) && cellView.DSJIOSADJIO)
                {
                    ItemMono itemMono = jioqweijoeqwioj.Get();
                    itemMono.SetPosition(cellView.transform.position+Vector3.up);
                    cellView.Init(itemMono);
                }
            }
        }
    }
}