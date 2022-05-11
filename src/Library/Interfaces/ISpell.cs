namespace RoleplayGame
{
    /// <summary>
    /// Pueden existir muchos spells, y estos pueden variar. Con el codigo previo Spell podia tener varias
    /// instancias pero sus valores de defensevalue y attackvalue siempre serian los mismos. Con ISpell podemos
    /// en el spellbook depender de ISpell envez de una unica clase con un solo valor de attack y defensevalue
    /// y que con cada spell nuevo que queramos crear agregar nuevas clases que implementen ISpell sin modificar
    /// el codigo de SpellsBook.
    /// </summary>
    public interface ISpell
    {
        int AttackValue {get; }
        int DefenseValue {get; }
    }
}