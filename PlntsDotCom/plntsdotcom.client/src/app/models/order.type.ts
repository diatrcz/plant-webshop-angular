export interface Order {
    id: number;
    orderDate: Date;
    statusId: number;
    status?: {
      statusId: number;
      name: string;
    };
    orderItems: OrderItem[];
    invoice?: {
      id: number;
      amount: number;
      invoiceDate: Date;
    };
  }
  
  export interface OrderItem {
    id: number;
    orderId: number;
    productId: number;
    quantity: number;
    product?: {
      id: number;
      name: string;
      price: number;
      description?: string;
      imageUrl?: string;
    };
  }