public enum PieceState
{
    Falling = 0,
    FreeFall = 1,
    IsPlaced = 2,
    InStableState = 3,
    Disabled = 4
}

public enum GameModeType
{
    SinglePlayer = 0,
    TwoPlayer = 1
}

public enum GameStates
{
    StartState = 0,
    GameplayState = 1,
    PauseState = 2,
    GameOverState = 3
}

public enum PlayerTags
{
    Player0 = 0,
    Player1 = 1
}
