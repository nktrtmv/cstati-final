-- +goose Up
-- +goose StatementBegin
CREATE TABLE accounts
(
    login             TEXT      NOT NULL,
    password          TEXT      NOT NULL,
    full_name         TEXT      NOT NULL,
    data              JSONB,
    is_deleted        BOOLEAN   NOT NULL DEFAULT FALSE,
    concurrency_token TIMESTAMP NOT NULL DEFAULT (CURRENT_TIMESTAMP AT TIME ZONE 'utc'),
    PRIMARY KEY (login)
);
-- +goose StatementEnd

-- +goose Down
-- +goose StatementBegin
-- +goose StatementEnd
