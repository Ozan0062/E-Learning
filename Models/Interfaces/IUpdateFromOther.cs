﻿
/// <summary>
/// This interface must be implemented by any entity
/// which is to be handled by a data service.
/// </summary>
public interface IUpdateFromOther< T>
{
    void Update(T tOther);
}
