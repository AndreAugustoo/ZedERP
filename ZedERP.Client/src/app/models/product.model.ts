export class Product {
  id?: number;
  code: string;
  name: string;
  groupId?: number;
  unitId?: number;
  salePrice: number;
  stock: number;
  image?: string;

  constructor(
    code: string,
    name: string,
    salePrice: number,
    stock: number,
    groupId?: number,
    unitId?: number,
    image?: string,
    id?: number
  ) {
    this.code = code;
    this.name = name;
    this.salePrice = salePrice;
    this.stock = stock;
    this.groupId = groupId;
    this.unitId = unitId;
    this.image = image;
    this.id = id;
  }
}
