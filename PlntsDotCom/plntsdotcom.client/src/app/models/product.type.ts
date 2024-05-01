import { Category } from "./category.type";
import { OrderedItem } from "./ordereditem.type";

export interface Product {
  id: number;
  name: string;
  price: number;
  stock?: number | null;
  description?: string | null;
  categoryId: number;
  category?: Category | null;
  orderedItems: OrderedItem[];
  imageUrl?: string | null;
  quantity?: number | null;
}