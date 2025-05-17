namespace ToyRobot.Domain;

public class Robot
{
    private Position? _position;
    private Direction? _direction;
    private Table _table;
    
    public Position? Position => _position;
    public Direction? Direction => _direction;
    
    public bool IsPlaced => _position is not null && _direction is not null;
    
    public void Place(Position position, Direction direction, Table table)
    {
        if (!table.IsValidPosition(position)) 
            return;
        
        _position = position;
        _direction = direction;
        _table = table;
    }
    
    public void Move()
    {
        if (!IsPlaced)
            return;
        
        var newPosition = _position!.Value.Move(_direction!.Value);
        if (_table.IsValidPosition(newPosition))
            _position = newPosition;
    }
}