const url = "http://localhost:8088";

export const getAllProducts = () => {
    return fetch(`${url}/products`).then((res) => res.json())
}
export const getOneProduct = (id) => {
    return fetch(`${url}/products/${id}`).then((res) => res.json())
}