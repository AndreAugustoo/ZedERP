import { Product } from './product.model';

describe('Product', () => {
  it('should create an instance', () => {
    expect(new Product('P001', 'Product Name', 1, 1, 100.0, 50)).toBeTruthy();
  });
});
