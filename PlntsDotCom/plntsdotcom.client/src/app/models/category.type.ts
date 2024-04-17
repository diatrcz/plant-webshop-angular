import { Product } from "./product.type";

export interface Category {
  id: number;
  name: string;
  parentCategoryId: number;
  inverseParentCategory: Category[];
  parentCategory: Category | undefined; 
  products: Product[]; 
}
