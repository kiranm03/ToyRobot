namespace ToyRobot.Domain;

public class Robot(Table table)
{
    private Position? _position;
    private Direction? _direction;

    public Position? Position => _position;
    public Direction? Direction => _direction;
    
    public bool IsPlaced => _position is not null || _direction is not null;
    
    public void Place(Position position, Direction direction)
    {
        if (!table.IsValidPosition(position)) 
            return;
        
        _position = position;
        _direction = direction;
    }
    
    public void Move()
    {
        if (!IsPlaced)
            return;
        
        var newPosition = _position!.Value.Move(_direction!.Value);
        if (table.IsValidPosition(newPosition))
            _position = newPosition;
    }
    
    public void TurnLeft()
    {
        if (!IsPlaced)
            return;
        
        _direction = _direction!.Value.TurnLeft();
    }
    
    public void TurnRight()
    {
        if (!IsPlaced)
            return;
        
        _direction = _direction!.Value.TurnRight();
    }
}