public enum BlockState
{
    Falling = 0,
    FreeFall = 1,
    IsPlaced = 2,
    InStableState = 3,
    Disabled = 4,
    FallAfterPlace = 5, // only to be used when block starts falling after the placement;
    FellOutOfBounds = 6
}

public enum GameModeType
{
    SinglePlayer = 0,
    TwoPlayer = 1
}

public enum GameStates
{
    StartState = 0,
    PlayState = 1,
    PauseState = 2,
    GameOverState = 3
}

public enum PlayerTags
{
    Player1 = 0,
    Player2 = 1
}

public enum MenuType
{
    StartMenu = 0,
    GameMenu = 1,
    Pause = 2,
    GameOver = 3
}

public enum BlockType
{
    I,
    J,
    L,
    T,
    O,
    S,
    Z
}
