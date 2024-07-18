export class Unit {
  id?: number;
  unitSymbol: string;
  description: string;

  constructor(unitSymbol: string, description: string, id?: number) {
    this.unitSymbol = unitSymbol;
    this.description = description;
    this.id = id;
  }
}
