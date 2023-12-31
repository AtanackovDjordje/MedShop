export interface Basket {
    basketId: number
    buyerId: string
    items: BasketItem[]
  }
  
  export interface BasketItem {
    productId: number
    name: string
    price: number
    pictureUrl: string
    type: string
    quantity: number
  }