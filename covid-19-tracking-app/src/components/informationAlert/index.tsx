import React, { useState, useEffect, ChangeEvent } from "react";
import * as bt from 'react-bootstrap';
import APIServices, { RequestBody } from "../../apis/apiServices";
import { Translation } from '../translation';
import { trackPromise } from 'react-promise-tracker';
import { Totals, TotalsRequest } from "../../apis/totals";
import { useAppContext } from '../../contexts/appContext';
import { ApiResponse } from "../../type";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
const InformationAlert: React.FC = () => {
    const [totals, setTotals] = useState<Totals>();
    const { appSetting } = useAppContext();

    useEffect(() => {
        retrieveTotals();
    }, []);

    const retrieveTotals = () => {
        const api = new APIServices("")
        const body = new RequestBody<TotalsRequest>("__");
        // trackPromise(
        fetch(
            appSetting.TotalsCase.Url, api.request(body))
            .then(res => res.json())
            .then(data => {
                const response: ApiResponse<Totals> = data;
                if (response.errorCode == undefined) {
                    if (response.success) {
                        setTotals(response.resource);
                    }
                    else {
                        toast(response.messages, {
                            position: "bottom-right",
                            autoClose: 10000,
                            hideProgressBar: true,
                        });
                    }
                }
                else {

                }
            })
            .catch(() => {
                toast("Error", {
                    position: "bottom-right",
                    autoClose: 10000,
                    hideProgressBar: true,
                });
            })
        // );
    };

    return (
        <>
            <ToastContainer />
            <bt.Container>
                <bt.Row>
                    <div className="p-1 mt-4 text-center">
                        <div className="container-fluid py-2">
                            <p className="col-md-12 fs-4">
                                <Translation tid="who_reported_desciption1" />

                                <Translation tid="who_reported_desciption2" />
                                <span className="text-warning">{totals?.confirmed}</span>
                                <Translation tid="who_reported_desciption3" />
                                <span className="text-danger">{totals?.deaths}</span>
                                <Translation tid="who_reported_desciption4" />
                            </p>
                        </div>
                    </div>
                </bt.Row>
            </bt.Container>
        </>

    )
}

export default InformationAlert;
