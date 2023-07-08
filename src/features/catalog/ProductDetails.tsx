import { Divider, Grid, Table, TableBody, TableCell, TableContainer, TableRow, TextField, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import LoadingComponent from "../../app/layout/LoadingComponent";
import NotFound from "../../app/errors/NotFound";
import { LoadingButton } from "@mui/lab";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import { fetchProductAsync, productSelectors } from "./catalogSlice";
import { addBasketItemAsync, removeBasketItemAsync } from "../basket/basketSlice";

export default function ProductDetails() {

    const { basket, status } = useAppSelector(state => state.basket);
    const dispatch = useAppDispatch();
    const { productId } = useParams<{ productId: string }>();
    const product = useAppSelector(state => productSelectors.selectById(state, productId!));
    const {status: productStatus} = useAppSelector(state => state.catalog);
    const [quantity, setQuantity] = useState(0);
    const item = basket?.items.find(i => i.productId === product?.productId);

    useEffect(() => {
        if (!product && productId) dispatch(fetchProductAsync(parseInt(productId)))
    }, [productId, item, product, dispatch]);

      function handleInputChange(e: any) {
        if (e.target.value >= 0)
            setQuantity(parseInt(e.target.value));
    }

    function handleUpdateCart() {
        if (!item || quantity > item?.quantity) {
            const updatedQuantity = item ? quantity - item.quantity : quantity;
            dispatch(addBasketItemAsync({productId: product?.productId!, quantity: updatedQuantity}))
        } else {
            const updatedQuantity = item.quantity - quantity;
            dispatch(removeBasketItemAsync({productId: product?.productId!, quantity: updatedQuantity}))
        }
    }

    if (productStatus.includes('pending')) return <LoadingComponent message="Loading product..." />

      if (!product) return <NotFound />

    return (
        <Grid container spacing={6}>
        <Grid item xs={6}>
            <img src={product.pictureUrl} alt={product.name} style={{ width: '100%' }} />
        </Grid>
        <Grid item xs={6}>
            <Typography variant='h3'>{product.name}</Typography>
            <Divider sx={{ mb: 2 }} />
            <Typography variant='h4' color='secondary'>{product.price} RSD</Typography>
            <TableContainer>
                <Table>
                    <TableBody sx={{ fontSize: '1.1em' }}>
                        <TableRow>
                            <TableCell>Naziv proizvoda</TableCell>
                            <TableCell>{product.name}</TableCell>
                        </TableRow>
                        <TableRow>
                            <TableCell>Opis</TableCell>
                            <TableCell>{product.description}</TableCell>
                        </TableRow>
                        <TableRow>
                            <TableCell>Tip proizvoda</TableCell>
                            <TableCell>{product.type}</TableCell>
                        </TableRow>
                        <TableRow>
                            <TableCell>Dostupna kolicina proizvoda</TableCell>
                            <TableCell>{product.quantityInStock}</TableCell>
                        </TableRow>
                    </TableBody>
                </Table>
            </TableContainer>
            <Grid container spacing={2}>
                <Grid item xs={6}>
                    <TextField
                        onChange={handleInputChange}
                        variant={'outlined'}
                        type={'number'}
                        label={'Kolicina u korpi'}
                        fullWidth
                        value={quantity}
                    />
                </Grid>
                <Grid item xs={6}>
                    <LoadingButton
                        disabled={item?.quantity === quantity || !item && quantity === 0}
                        loading={status.includes('pending')}
                        onClick={handleUpdateCart}
                        sx={{ height: '55px' }}
                        color={'primary'}
                        size={'large'}
                        variant={'contained'}
                        fullWidth>
                        {item ? 'Azuriraj kolicinu' : 'Add to Cart'}
                    </LoadingButton>
                </Grid>
            </Grid>
        </Grid>
    </Grid>
    )
}