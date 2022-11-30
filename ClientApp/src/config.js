const config = { 
    baseApiUrl: "https://localhost:4000"
}

const currencyFormatter = Intl.NumberFormat("en-NZ", {
    style: "currency",
    currency: "NZD",
    maximumFractionDigits: 0
});

export default config;
export {currencyFormatter};