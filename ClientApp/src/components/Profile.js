import { currencyFormatter } from "../config";
import { useNavigate } from "react-router-dom";
import { useFetchProfile } from "../hooks/ProfileHooks";
import { useState } from "react";

export default function Profile() {

    const { data } = useFetchProfile();
    const nav = useNavigate();

    return (
        <div>
            <div className="row mb-2">
                <h5 className="themeFontColor text-center">
                    Calculate Profile Module
                </h5>
            </div>
            <table className="table table-hover">
                <thead>
                    <tr>
                        <th>Sale Year</th>
                        <th>Percentage Rent Tier 1</th>
                        <th>Percentage Rent Tier 2</th>
                        <th>Percentage Rent Tier 3</th>
                    </tr>
                </thead>
                <tbody>
                    {data && data.sales.map(h => (
                        <tr key={h.id}>
                            <td>{h.yearOfSale}</td>
                            <td>{currencyFormatter.format(h.tierOne.teirPercentageRent)}</td>
                            <td>{currencyFormatter.format(h.tierTwo.teirPercentageRent)}</td>
                            <td>{currencyFormatter.format(h.tierThree.teirPercentageRent)}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
            <table className="table table-hover">
                <thead>
                    <tr>
                        {data && data.sales.map(h => (
                            <th key={h.id}>
                                Year {h.yearOfSale}
                            </th>
                        ))}
                    </tr>
                </thead>
                <tbody>
                    {/* { data &&
                        <tr>
                            <td>{currencyFormatter.format(data.sales.reduce((a, v) => a = a + v.tierOne.teirPercentageRent, 0))}</td>
                            <td>{currencyFormatter.format(data.sales.reduce((a, v) => a = a + v.tierTwo.teirPercentageRent, 0))}</td>
                            <td>{currencyFormatter.format(data.sales.reduce((a, v) => a = a + v.tierThree.teirPercentageRent, 0))}</td>
                        </tr>
                    } */}
                </tbody>
            </table>
        </div>
    );
}