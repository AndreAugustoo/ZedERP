import { Unit } from './unit.model';

describe('Unit', () => {
  it('should create an instance', () => {
    expect(new Unit('KM', 'Quilômetro')).toBeTruthy();
  });
});
