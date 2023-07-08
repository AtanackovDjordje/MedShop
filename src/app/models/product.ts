export interface Product{
    productId: number
    name: string
    description: string
    price: number
    pictureUrl: string
    type: string
    quantityInStock: number
}

export interface ProductParams {
    orderBy: string;
    searchTerm?: string;
    types: string[];
    pageNumber: number;
    pageSize: number;
}