using System;
using UnityEngine;

public static class GameEvents
{
    // Sự kiện Xe & Đạo cụ
    public static Action<CarEntity> OnCarSpawned;
    public static Action<CarEntity, Sprite> OnItemSlotUpdated;
    public static Action<CarEntity, int> OnLapCompleted; // Xe nào, Vòng mấy

    // Sự kiện Trận đua
    public static Action OnRaceStarted;
    public static Action<CarEntity> OnRaceFinished;
}
