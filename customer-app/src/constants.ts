export interface Product {
  id: number;
  name: string;
  description: string;
  quantity: number;
  price: number;
}

export const initialProducts: Product[] = [
  { id: 1, name: 'Product 1', description: 'Description 1', quantity: 10, price: 9.99 },
  { id: 2, name: 'Product 2', description: 'Description 2', quantity: 5, price: 19.99 },
  { id: 3, name: 'Product 3', description: 'Description 3', quantity: 20, price: 4.99 },
  { id: 4, name: 'Product 4', description: 'Description 4', quantity: 15, price: 14.99 },
];
